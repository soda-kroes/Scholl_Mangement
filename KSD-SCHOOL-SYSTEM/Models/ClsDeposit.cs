using System;
using System.Collections.Generic;

namespace KSD_SCHOOL_SYSTEM.Models
{
    public class ClsDeposit
    {
        public int DocEntry { get; set; }
        public string StuName { get; set; }
        public string StuPhone { get; set; }
        public DateTime PostingDate { get; set; }
        //public DateTime StudyDate { get; set; }
        public string UserCode { get; set; }    
        public decimal Total { get; set; }
        public decimal Deposti { get; set; }    
        public decimal Balance { get; set; }
        public List<LevelDeposit> levelDeposits { get; set; }
    }

    public class LevelDeposit
    {
        public int DocEntry { get; set;}
        public string LevelCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal discountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public string Time { get; set; }
        public string schedule { get; set; }

    }
}
