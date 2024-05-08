using System;

namespace KSD_SCHOOL_SYSTEM.Models
{
    public class ClsBranch
    {
        public int DocEntry { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }  
        public string TaxCode { get; set; }
        public double TaxPer { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
    }
}
