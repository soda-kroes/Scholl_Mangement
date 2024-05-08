using KSD_SCHOOL_SYSTEM.Models;
using KSD_SCHOOL_SYSTEM.Models.Return;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace KSD_SCHOOL_SYSTEM.Controllers
{
    public class UserController : Controller
    {
        public IActionResult ViewUser()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            return RedirectToAction("LoginPage","Login");
          
        }


        [HttpPost]
        public IActionResult PostUser(ClsUser user)
        {
            ReturnStatus Status = new ReturnStatus();
            ClsConnection con = new ClsConnection();

            if (con._ErrCode == 0)
            {

            //    SqlTransaction trans = con._Con.BeginTransaction();

                try
                {
                    DateTime dt = DateTime.Now;
                    user.Change = "N";
                    user.CreateBy = "";
                    user.ExpiredDate = dt;
                    user.Password = "abc123";
                    user.Locked = "N";
                    user.ExpiredDate = dt.AddDays(1);

                    bool find = false;
                    DataTable table = new DataTable();

                    string query = "select *from tblUser where UserCode in('"+user.UserCode+"')";
                    con._Ad = new SqlDataAdapter(query,con._Con);
                    con._Ad.Fill(table);

                    foreach(DataRow row in table.Rows)
                    {
                        find = true;
                    }

                    if(!find)
                    {
                        con._Cmd = new SqlCommand();
                        con._Cmd.Connection = con._Con;
                        con._Cmd.CommandText = "Insert Into tblUser Values(N'" + user.UserCode + "',N'" + user.FullName + "'" +
                        ",N'" + user.EmpCode + "',N'" + user.Branch + "',N'" + user.Password + "'" +
                        ",N'" + user.Role + "','N','N',N'" + dt.ToString("yyyy-MM-dd") + "',N'" + user.CreateBy + "'" +
                        ",N'" + user.ExpiredDate.ToString("yyyy-MM-dd") + "','N','A')";

                    //  con._Cmd.Transaction = trans;
                        con._Cmd.ExecuteNonQuery();

                        Status.ErrCode = 0;
                        Status.ErrMsg = "Data Insert Successfully";

                    }
                    else
                    {
                        Status.ErrCode = 99999;
                        Status.ErrMsg = "UserCode Not Available";
                    }
                   

                   // trans.Commit();
                }
                catch (Exception ex)
                {
                   // trans.Rollback();
                    Status.ErrCode = ex.HResult;
                    Status.ErrMsg =  ex.Message;
                }
                finally
                {
                  // trans.Dispose();    
                }

            }
            else
            {
                Status.ErrCode = con._ErrCode;
                Status.ErrMsg = con._ErrMsg;

            }
            
            return Ok(Status);
        }

        public IActionResult GetUser()
        {
            
            ClsConnection con = new ClsConnection();    
            ReturnUser returnUser = new ReturnUser();   
            if(con._ErrCode == 0) {
                SqlTransaction trans = con._Con.BeginTransaction();
                List<ClsUser> users = new List<ClsUser>();
                ClsUser obj;

                try
                {
                    DataTable table = new DataTable();
                    //string query = "select *from tblUser";
                    string query = "SELECT [DocEntry]\r\n      ,[UserCode]\r\n      ,[FullName]\r\n      ,[EmpCode]\r\n      ,[Branch]\r\n      ,[Password]\r\n      ,CASE WHEN Role IN ('A') THEN 'Admin' ELSE 'User' END AS UserRole\r\n      ,CASE WHEN Locked = 'N' THEN 'No' ELSE 'Yes' END AS Locked\r\n      ,[Change]\r\n      ,[CreateDate]\r\n      ,[CreateBy]\r\n      ,[ExpiredDate]\r\n      ,[ExpiredLocked]\r\n      ,CASE WHEN Status IN ('A') THEN 'Active' ELSE 'Inactive' END AS UserStatus\r\nFROM [tblUser];";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.Transaction = trans;
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsUser();
                        obj.DocEntry = Convert.ToInt32(row[0].ToString());  
                        obj.UserCode = row[1].ToString();
                        obj.FullName = row[2].ToString();   
                        obj.EmpCode = row[3].ToString();    
                        obj.Branch = row[4].ToString(); 
                        obj.Password = row[5].ToString();   
                        obj.Role = row[6].ToString();   
                        obj.Locked = row[7].ToString(); 
                 //       obj.CreateDate = Convert.ToDateTime(row[9].ToString());
                        obj.CreateBy = row[10].ToString();

                        if(obj.Change=="N"  && obj.ExpiredDate < DateTime.Now)
                        {
                            obj.ExpiredLocked = "Y";
                        }
                        else
                        {
                            obj.ExpiredLocked = "N";
                        }
                        obj.ExpiredLocked = row[12].ToString(); 
                        obj.Status = row[13].ToString();
                        users.Add(obj);
                    }
                    returnUser.ErrCode = 0;
                    returnUser.Users = users.ToList();
                    trans.Commit(); 
                }catch (Exception ex) { 
                    trans.Rollback();   
                    returnUser.ErrCode=ex.HResult;
                    returnUser.ErrMsg=ex.Message;
                }
                finally { 
                    trans.Dispose(); 
                }

            }
            else
            {
                returnUser.ErrCode = con._ErrCode;
                returnUser.ErrMsg = con._ErrMsg;

            }
            return Ok(returnUser);
        }

        public IActionResult DeleteUser(int docentry)
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
                    con._Cmd.CommandText = "DELETE FROM tblUser WHERE DocEntry in("+docentry+")";

                    con._Cmd.Transaction = trans;
                    con._Cmd.ExecuteNonQuery();
                    trans.Commit();

                    returnStatus.ErrCode = 0;
                    returnStatus.ErrMsg = "Data Delete Successfully";


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


        public IActionResult UpdateUser(ClsUser user)
        {

            ReturnStatus Status = new ReturnStatus();
            ClsConnection con = new ClsConnection();
          
            SqlTransaction trans = con._Con.BeginTransaction();

                try
                {
                    con._Cmd = new SqlCommand();
                    con._Cmd.Connection = con._Con;
                    string sql = "UPDATE tblUser SET FullName = N'"+user.FullName+"', EmpCode = '"+user.EmpCode+"', Branch = '"+user.Branch+"', Role = '"+user.Role+"', Locked = '"+user.Locked+"', Status = '"+user.Status+"' WHERE UserCode in('"+user.UserCode+"')";
                   con._Cmd.CommandText = sql;
                    con._Cmd.Transaction = trans;
                    con._Cmd.ExecuteNonQuery();

                    Status.ErrCode = 0;
                    Status.ErrMsg = "Data Update Successfully";
                     trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Status.ErrCode = ex.HResult;
                    Status.ErrMsg = ex.Message;
                }
                finally
                {
                    trans.Dispose();    
                }

           
            return Ok(Status);
        }

        public IActionResult ResetUser(string Usercode)
        {
            ReturnStatus Status = new ReturnStatus();
            ClsConnection con = new ClsConnection();

            SqlTransaction trans = con._Con.BeginTransaction();

            try
            {
                DateTime dt = DateTime.Now.AddDays(2); 
                con._Cmd = new SqlCommand();
                con._Cmd.Connection = con._Con;
                string sql = "UPDATE tblUser SET ExpiredDate= '"+dt.ToShortDateString()+ "' WHERE UserCode in('"+Usercode+"')";
                con._Cmd.CommandText = sql;
                con._Cmd.Transaction = trans;
                con._Cmd.ExecuteNonQuery();

                Status.ErrCode = 0;
                Status.ErrMsg = "Reset User Successfully";
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Status.ErrCode = ex.HResult;
                Status.ErrMsg = ex.Message;
            }
            finally
            {
                trans.Dispose();
            }

            return Ok(Status);
        }

    }

}
