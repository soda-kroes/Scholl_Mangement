using KSD_SCHOOL_SYSTEM.Models;
using KSD_SCHOOL_SYSTEM.Models.Return;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace KSD_SCHOOL_SYSTEM.Controllers
{
    public class BranchController : Controller
    {
        public IActionResult ViewBranch()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Login");
            }
        }

        [HttpPost]
        public IActionResult CreateBranch(ClsBranch branch)
        {
            ReturnStatus status = new ReturnStatus();
            ClsConnection con = new ClsConnection();
            if (con._ErrCode == 0)
            {
                try
                {
                    DateTime dat = DateTime.Now;

                    bool find = false;
                    DataTable dt = new DataTable();
                    con._Ad = new SqlDataAdapter("SELECT * FROM tblBranch WHERE BranchCode = @BranchCode", con._Con);
                    con._Ad.SelectCommand.Parameters.AddWithValue("@BranchCode", branch.BranchCode);
                    con._Ad.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        find = true;
                    }
                    if (!find)
                    {
                        con._Cmd = new SqlCommand();
                        con._Cmd.Connection = con._Con;
                        con._Cmd.CommandText = "INSERT INTO tblBranch VALUES (@BranchCode, @BranchName, @TaxCode, @TaxPer, @Address, @Status, @CreateBy,@CreatDate )";
                        con._Cmd.Parameters.AddWithValue("@BranchCode", branch.BranchCode);
                        con._Cmd.Parameters.AddWithValue("@BranchName", branch.BranchName);
                        con._Cmd.Parameters.AddWithValue("@TaxCode", branch.TaxCode);
                        con._Cmd.Parameters.AddWithValue("@TaxPer", branch.TaxPer);
                        con._Cmd.Parameters.AddWithValue("@Address", branch.Address);
                        con._Cmd.Parameters.AddWithValue("@CreatDate", dat.ToString("yyyy-MM-dd HH:mm:ss"));
                        con._Cmd.Parameters.AddWithValue("@CreateBy", HttpContext.Session.GetString("Code"));
                        con._Cmd.Parameters.AddWithValue("@Status", branch.Status);
                        con._Cmd.ExecuteNonQuery();
                        status.ErrCode = 0;
                        status.ErrMsg = "Branch Create Success.";
                    }
                    else
                    {
                        status.ErrCode = 1;
                        status.ErrMsg = "Branch Code Not Available.";
                    }
                }
                catch (Exception ex)
                {
                    status.ErrCode = ex.HResult;
                    status.ErrMsg = ex.Message;
                }
            }
            else
            {
                status.ErrCode = con._ErrCode;
                status.ErrMsg = con._ErrMsg;
            }
            return Ok(status);
        }

        public IActionResult GetAllBranch()
        {
            ReturnBranch returnBranch = new ReturnBranch();
            ClsConnection con = new ClsConnection();    
            if(con._ErrCode==0)
            {
                List<ClsBranch> list = new List<ClsBranch>();
                ClsBranch obj;

                try
                {
                    DataTable dt = new DataTable();
                    con._Ad = new SqlDataAdapter(" select *,FORMAT(CreateDate,'dd-MM-yyyy') as CreateDate_Format,CASE WHEN Status IN ('A') THEN 'Active' ELSE 'Inactive' END AS Branch_Status from tblBranch", con._Con);
                    con._Ad.Fill(dt);
                    foreach(DataRow row in dt.Rows)
                    {
                        obj = new ClsBranch();
                        obj.BranchCode = row[1].ToString();
                        obj.BranchName = row[2].ToString(); 
                        obj.TaxCode = row[3].ToString();
                        obj.TaxPer = Convert.ToDouble(row[4].ToString());   
                        obj.Address = row[5].ToString();
                        obj.CreateBy = row[7].ToString();
                        obj.CreateDate = row[9].ToString();
                        obj.Status = row[10].ToString();
                        list.Add(obj);
                    }
                    returnBranch.Branchs = list.ToList();
                    returnBranch.ErrCode = 0;
                    returnBranch.ErrMsg = "";
                 



                }catch(Exception ex)
                { 
                   returnBranch.ErrCode = ex.HResult;   
                   returnBranch.ErrMsg = ex.Message;    
                }
            }
            else
            {
                returnBranch.ErrCode= con._ErrCode; 
                returnBranch.ErrMsg= con._ErrMsg;
            }
            return Ok(returnBranch);
        }

        public IActionResult UpdateBranch(ClsBranch branch)
        {
            ReturnStatus status = new ReturnStatus();   
            ClsConnection con = new ClsConnection();
            if (con._ErrCode == 0)
            {
                try
                {
                    con._Cmd = new SqlCommand();
                    con._Cmd.Connection = con._Con;
                    string query = "UPDATE tblBranch SET BranchName=@BranchName, TaxCode=@TaxCode, TaxPer=@TaxPer, Address=@Address, Status=@Status WHERE BranchCode=@BranchCode";
                    con._Cmd.CommandText = query;
                    con._Cmd.Parameters.AddWithValue("@BranchName",branch.BranchName);
                    con._Cmd.Parameters.AddWithValue("@TaxCode", branch.TaxCode);
                    con._Cmd.Parameters.AddWithValue("@TaxPer", branch.TaxPer);
                    con._Cmd.Parameters.AddWithValue("@Address", branch.Address);
                    con._Cmd.Parameters.AddWithValue("@Status", branch.Status);
                    con._Cmd.Parameters.AddWithValue("@BranchCode", branch.BranchCode);
                    con._Cmd.ExecuteNonQuery();

                    status.ErrCode = 0;
                    status.ErrMsg = "Branch Update Success.";

                }
                catch(Exception ex) 
                {
                    status.ErrCode = ex.HResult;
                    status.ErrMsg = ex.Message;
                }


            }
            else
            {
                status.ErrCode = con._ErrCode;  
                status.ErrMsg = con._ErrMsg;
            }
            return Ok(status); 
        }
    }
}
