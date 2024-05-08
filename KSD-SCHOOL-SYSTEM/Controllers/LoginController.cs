using KSD_SCHOOL_SYSTEM.Models.Return;
using KSD_SCHOOL_SYSTEM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System;
using Microsoft.AspNetCore.Http;

namespace KSD_SCHOOL_SYSTEM.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
           return View();

        }

        public IActionResult CheckLogin(string UserCode,string Password)
        {
            ReturnStatus Status = new ReturnStatus();
            ClsConnection con = new ClsConnection();
            ClsUser obj = new ClsUser();
           // ClsBranch objBranch = new ClsBranch();

            if (con._ErrCode == 0)
            {
                try
                {
                    bool find = false;
                    DataTable table = new DataTable();

                    string query = "select *from tblUser where UserCode in('" +UserCode+ "') and Password in('"+Password+"')";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        find = true;
                        obj.DocEntry = Convert.ToInt32(row[0].ToString());
                        obj.UserCode = row[1].ToString();
                        obj.FullName = row[2].ToString();
                        obj.EmpCode = row[3].ToString();
                        obj.Branch = row[4].ToString();
                        obj.Password = row[5].ToString();
                        obj.Role = row[6].ToString();
                        if (obj.Role == "A")
                        {
                            obj.Role = "Administration";
                        }
                        else
                        {
                            obj.Role = "User";
                        }
                        obj.Locked = row[7].ToString();
                        obj.Change = row[8].ToString(); 
                        obj.CreateDate = Convert.ToDateTime(row[9].ToString());
                        obj.CreateBy = row[10].ToString();
                        obj.ExpiredDate = Convert.ToDateTime(row[11].ToString());
                        obj.Status = row[13].ToString();
                        HttpContext.Session.SetString("UserName", obj.FullName); // Set the session with the user's name

                    }

                    DataTable dt = new DataTable();
                  
                    string sql = "select *from tblBranch where branchCode in('" + obj.Branch + "') and Status in('I')";
                    con._Ad = new SqlDataAdapter(sql, con._Con);
                    con._Ad.Fill(dt);

                    bool branch = true;
                    if (dt.Rows.Count > 0 )
                    {
                        branch = false;
                        //objBranch.BranchName = dt.Rows[0]["BranchName"].ToString(); // Assuming "Bran
                    }

                    
                    

                    if (find)
                    {
                        if (obj.Status == "I")
                        {
                            Status.ErrCode = 1;
                            Status.ErrMsg = "User is inactice please contact to admin";

                        }
                        else if (obj.Locked == "Y")
                        {
                            Status.ErrCode = 2;
                            Status.ErrMsg = "User is locked please contact to admin";
                        }

                        else if(obj.ExpiredDate < DateTime.Now && obj.Change=="N")
                        {
                            Status.ErrCode = 3;
                            Status.ErrMsg = "User is expired please contact to admin";
                        }
                        else if (obj.Change == "N")
                        {
                            HttpContext.Session.SetString("tmpBranch", obj.Branch);
                            HttpContext.Session.SetString("Role", obj.Role);
                            HttpContext.Session.SetString("tmpCode", UserCode);
                            HttpContext.Session.SetString("tmpBranch", "");
                            Status.ErrCode = 4;
                            Status.ErrMsg = "";
                        }
                        else if (branch == false)
                        {
                            Status.ErrCode = 5;
                            Status.ErrMsg = "Branch is blocks.";
                        }
                        else
                        {

                         
                            HttpContext.Session.SetString("Branch", obj.Branch);
                            HttpContext.Session.SetString("Role",obj.Role);
                            HttpContext.Session.SetString("Code",UserCode);
                            Status.ErrCode = 0;
                            Status.ErrMsg = "Login Successfully";
                        }

                       
                    }
                    else
                    {
                        Status.ErrCode = 99999;
                        Status.ErrMsg = "UserCode Or Password Incorrect.";
                    }
                }
                catch (Exception ex)
                {
                    Status.ErrCode = ex.HResult;
                    Status.ErrMsg = ex.Message;
                }
            }
            else
            {
                Status.ErrCode = con._ErrCode;
                Status.ErrMsg = con._ErrMsg;

            }

            return Ok(Status);
        }

        public IActionResult ChangeDefaultPassword()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("tmpCode")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Login");

            }
           
        }

        public IActionResult PostChangePassword(string NewPassword)
        {
            ClsConnection con = new ClsConnection();
            ReturnStatus returnStatus = new ReturnStatus();
            if (con._ErrCode == 0)
            {
                SqlTransaction trans = con._Con.BeginTransaction();
                try
                {

                    con._Cmd = new SqlCommand();
                    con._Cmd.Connection = con._Con;
                    con._Cmd.CommandText = "UPDATE tblUser SET Password = '"+NewPassword+"', Change='Y' WHERE UserCode in('"+HttpContext.Session.GetString("tmpCode")+"')";

                    con._Cmd.Transaction = trans;
                    con._Cmd.ExecuteNonQuery();

                    HttpContext.Session.SetString("Branch", HttpContext.Session.GetString("tmpBranch"));
                    HttpContext.Session.SetString("Code", HttpContext.Session.GetString("tmpCode"));
                    HttpContext.Session.SetString("tmpCode","");
                 

                    returnStatus.ErrCode = 0;
                    returnStatus.ErrMsg = "Change Password Successfully";
                    trans.Commit();


                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    returnStatus.ErrCode = ex.HResult;
                    returnStatus.ErrMsg = ex.Message;
                }
                finally
                {
                    trans.Dispose();
                }
            }
            else
            {

                returnStatus.ErrCode = con._ErrCode;
                returnStatus.ErrMsg = con._ErrMsg;
            }


            return Ok(returnStatus);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "Login");
        }

    }
}
