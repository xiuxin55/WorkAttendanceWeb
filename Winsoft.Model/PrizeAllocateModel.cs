using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsoft.Model
{
    public class PrizeAllocateModel
    {
        public string Guid { get; set; }
        public string PrizeID { get; set; }
        public string PrizeName { get; set; }
        public string WebsiteID { get; set; }
        public string WebsiteName { get; set; }
        public int PrizeCount { get; set; }
        public int PrizeUsedAmount { get; set; }
        public int PrizeAmount { get; set; }
        public string PrizeScore { get; set; }
        
    }
    public class PrizeInfo
    {
        public string PrizeID { get; set; }
        public string PrizeName { get; set; }
        public string PrizeLeftAmount { get; set; }
        public string PrizeUsedAmount { get; set; }
        public string PrizeAmount { get; set; }
        public string PrizeScore { get; set; }
        
    }

}
