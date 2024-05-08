using System.Collections.Generic;

namespace KSD_SCHOOL_SYSTEM.Models.Return
{
    public class ReturnLevel
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<ClsLevel> Level { get; set; }

    }
}
