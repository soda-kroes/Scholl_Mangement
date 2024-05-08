using System;

namespace KSD_SCHOOL_SYSTEM.Models
{
    public class ClsUser
    {
        public int DocEntry { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string EmpCode { get; set; }
        public string Branch { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Locked { get; set; }
        public string Change { get; set; }//not use use in backagroud
        public DateTime CreateDate { get; set; }//not use use in backagroud
        public string CreateBy { get; set; }//not use use in backagroud
        public DateTime ExpiredDate { get; set; }//not use use in backagroud
    
        public string ExpiredLocked { get; set; }
        public string Status { get; set; }
    }
}
