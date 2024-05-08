using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KSD_SCHOOL_SYSTEM.Models
{
    public class ClsConnection
    {
        private int ErrCode;
        private string ErrMsg;
        private SqlConnection con;

        public int    _ErrCode { get { return ErrCode; } }//read only
        public string _ErrMsg { get { return ErrMsg; } }//read only
        public SqlConnection _Con { get { return con; } }//read only
       
        public SqlCommand _Cmd { get; set; }
        public SqlDataAdapter _Ad { get; set; }

        public ClsConnection()
        {
            getConnection();
        }

        private void getConnection()
        {
            try
            {
               //   string constr = "Server=10.18.1.150;Initial Catalog=KSD_DB;User ID=cpb_int;Password=123cp!@#";
                string constr = @"Server=DESKTOP-FQ90H1P\SQLEXPRESS;Initial Catalog=SMS;User ID=KSD;Password=SODA@168;TrustServerCertificate=True";
                con = new SqlConnection(constr);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                if(con.State == System.Data.ConnectionState.Open)
                {
                    ErrCode = 0;
                }
                else
                {
                    ErrCode = 9999999;
                    ErrMsg = "Unknow";
                }

            }catch (Exception ex)
            {
                ErrCode = ex.HResult;
                ErrMsg=ex.Message;  
            }
        }
    }
}


