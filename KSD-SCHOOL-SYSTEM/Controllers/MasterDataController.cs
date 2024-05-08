using KSD_SCHOOL_SYSTEM.Models.Return;
using KSD_SCHOOL_SYSTEM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace KSD_SCHOOL_SYSTEM.Controllers
{
    public class MasterDataController : Controller
    {
        public IActionResult GetAllBranch()
        {
            ReturnBranch returnBranch = new ReturnBranch();
            ClsConnection con = new ClsConnection();
            if (con._ErrCode == 0)
            {
                List<ClsBranch> list = new List<ClsBranch>();
                ClsBranch obj;

                try
                {
                    DataTable dt = new DataTable();
                    con._Ad = new SqlDataAdapter("SELECT *from tblBranch WHERE Status in('A')", con._Con);
                    con._Ad.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        obj = new ClsBranch();
                        obj.BranchCode = row[1].ToString();
                        obj.BranchName = row[2].ToString();
                       
                        list.Add(obj);
                    }
                    returnBranch.Branchs = list.ToList();
                    returnBranch.ErrCode = 0;
                    returnBranch.ErrMsg = "";




                }
                catch (Exception ex)
                {
                    returnBranch.ErrCode = ex.HResult;
                    returnBranch.ErrMsg = ex.Message;
                }
            }
            else
            {
                returnBranch.ErrCode = con._ErrCode;
                returnBranch.ErrMsg = con._ErrMsg;
            }
            return Ok(returnBranch);
        }


        public IActionResult getLevel()
        {
            ReturnLevel returnLevel = new ReturnLevel();
            ClsConnection con = new ClsConnection();
            if (con._ErrCode == 0)
            {
                List<ClsLevel> list = new List<ClsLevel>();
                ClsLevel obj;

                try
                {
                    DataTable dt = new DataTable();
                    con._Ad = new SqlDataAdapter("SELECT *from tblLevel where status in('A') and Branch in('"+HttpContext.Session.GetString("Branch")+"')", con._Con);
                    con._Ad.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        obj = new ClsLevel();
                        obj.LevelCode = row[1].ToString();
                        obj.LevelName = row[2].ToString();
                        obj.UnitPrice = Convert.ToDecimal(row[3].ToString());
                        list.Add(obj);
                    }
                    returnLevel.Level = list.ToList();
                    returnLevel.ErrCode = 0;
                    returnLevel.ErrMsg = "";




                }
                catch (Exception ex)
                {
                    returnLevel.ErrCode = ex.HResult;
                    returnLevel.ErrMsg = ex.Message;
                }
            }
            else
            {
                returnLevel.ErrCode = con._ErrCode;
                returnLevel.ErrMsg = con._ErrMsg;
            }
            return Ok(returnLevel);
        }
    }
}
