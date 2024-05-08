using System.Collections.Generic;

namespace KSD_SCHOOL_SYSTEM.Models.Return
{
    public class ReturnBranch
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<ClsBranch> Branchs { get; set; }
    }
}
