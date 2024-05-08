using System.Collections.Generic;

namespace KSD_SCHOOL_SYSTEM.Models.Return
{
    public class ReturnUser
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<ClsUser> Users { get; set; }  
    }
}
