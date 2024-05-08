using KSD_SCHOOL_SYSTEM.Models;
using KSD_SCHOOL_SYSTEM.Models.Return;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;

namespace KSD_SCHOOL_SYSTEM.Controllers
{
    public class LevelController : Controller
    {
        public IActionResult ViewLevel()
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
        public IActionResult CreateLevel(ClsLevel level)
        {
            ReturnStatus returnStatus = new ReturnStatus();
            ClsConnection con = new ClsConnection();
            try
            {
                bool check = false;
                DataTable dt = new DataTable();
                string query = "SELECT *FROM tblLevel WHERE LevelCode in('"+level.LevelCode+ "') And Branch in('" + HttpContext.Session.GetString("Branch") + "')";
                con._Ad = new SqlDataAdapter(query,con._Con);
                con._Ad.Fill(dt);  
                foreach(DataRow dataRow in dt.Rows)
                {
                    check = true;
                }
                if (!check)
                {
                    con._Cmd = new SqlCommand();
                    con._Cmd.Connection = con._Con;
                    con._Cmd.CommandText = "INSERT INTO tblLevel VALUES(@LevelCode,@LevelName,@UnitPrice,@Status,@Branch)";
                    con._Cmd.Parameters.AddWithValue("@LevelCode", level.LevelCode);
                    con._Cmd.Parameters.AddWithValue("@LevelName", level.LevelName);
                    con._Cmd.Parameters.AddWithValue("@UnitPrice", level.UnitPrice);
                    con._Cmd.Parameters.AddWithValue("@Status", level.Status);
                    con._Cmd.Parameters.AddWithValue("@Branch", HttpContext.Session.GetString("Branch"));
                    con._Cmd.ExecuteNonQuery();
                    returnStatus.ErrCode = 0;
                    returnStatus.ErrMsg = "Level Insert Success.";
                }
                else
                {
                    returnStatus.ErrCode = 1;
                    returnStatus.ErrMsg = "LevelCode Not Available.";
                }

            }catch(Exception ex)
            {
                returnStatus.ErrCode = ex.HResult;  
                returnStatus.ErrMsg = ex.Message;   
            }
            return Ok(returnStatus);
        }

        public IActionResult GetAllLevel()
        {
            ReturnLevel returnLevel = new ReturnLevel();
            ClsConnection con = new ClsConnection();
            if (con._ErrCode == 0)
            {
                SqlTransaction trans = con._Con.BeginTransaction(); 
                List<ClsLevel> levels = new List<ClsLevel>();
                ClsLevel obj;
                try
                {
                    DataTable dt = new DataTable();
                    string sql = "select *,CASE WHEN Status IN ('A') THEN 'Active' ELSE 'Inactive' END AS UserStatus from tblLevel WHERE Branch in('"+HttpContext.Session.GetString("Branch")+"')";
                    con._Ad = new SqlDataAdapter(sql,con._Con);
                    con._Ad.SelectCommand.Transaction = trans;  
                    con._Ad.Fill(dt);
                    foreach (DataRow row in dt.Rows) { 
                        obj = new ClsLevel();
                        obj.DocEntry = Convert.ToInt32(row[0]);
                        obj.LevelCode = row[1].ToString();
                        obj.LevelName = row[2].ToString();  
                        obj.UnitPrice = Convert.ToDecimal(row[3].ToString());   
                        obj.Status = Convert.ToString(row[5].ToString());   
                        levels.Add(obj);
                    }

                    returnLevel.Level = levels.ToList();    
                    returnLevel.ErrCode = 0;
                    returnLevel.ErrMsg = "";
                    trans.Commit(); 

                }catch(Exception ex) {
                    trans.Rollback();   
                    returnLevel.ErrCode = ex.HResult;
                    returnLevel.ErrMsg = ex.Message;
                    
                }
                finally {
                    trans.Dispose();
                }   

            }
            else {
                returnLevel.ErrCode = con._ErrCode;
                returnLevel.ErrMsg  = con._ErrMsg;
            }
            
            return Ok(returnLevel);
        }

        public IActionResult DeleteLevel(int docEntry)
        {
            ReturnStatus status = new ReturnStatus();   
            ClsConnection con = new ClsConnection();
            if(con._ErrCode== 0) {
                try
                {
                    con._Cmd = new SqlCommand();
                    con._Cmd.Connection = con._Con;
                    con._Cmd.CommandText = "DELETE tblLevel WHERE DocEntry = '"+docEntry+"'";
                    con._Cmd.ExecuteNonQuery();

                    status.ErrCode = 0;
                    status.ErrMsg = "Level Delete Success.";

                }
                catch (Exception ex)
                {
                    status.ErrCode=ex.HResult;
                    status.ErrMsg=ex.Message;

                }
            }
            else
            {
                status.ErrCode = con._ErrCode;  
                status.ErrMsg = con._ErrMsg;
            }
            return Ok(status);
        }
        public IActionResult UpdateLevel(ClsLevel level)
        {
            ReturnStatus status = new ReturnStatus();   
            ClsConnection con = new ClsConnection();
            if(con._ErrCode== 0) { 
                con._Cmd = new SqlCommand();
                con._Cmd.Connection = con._Con;
                con._Cmd.CommandText = "UPDATE tblLevel SET LevelName=@LevelName, UnitPrice=@UnitPrice, Status=@Status WHERE LevelCode=@LevelCode And Branch in('"+HttpContext.Session.GetString("Branch")+"')";
                con._Cmd.Parameters.AddWithValue("@LevelName",level.LevelName);
                con._Cmd.Parameters.AddWithValue("@UnitPrice",level.UnitPrice);
                con._Cmd.Parameters.AddWithValue("@Status", level.Status);
                con._Cmd.Parameters.AddWithValue("@LevelCode", level.LevelCode);
                con._Cmd.ExecuteNonQuery();

                status.ErrCode = 0;
                status.ErrMsg = "Level Update Success.";
            }
            else
            {
                status.ErrCode=con._ErrCode;
                status.ErrMsg = con._ErrMsg;
            }
        

            return Ok(status);
        }
    }
}

