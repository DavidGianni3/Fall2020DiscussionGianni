using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class Fund
    {
        [Key]//complete all the properties for this class
        public int FundID { get; set; }

        [Required]
        public string FundName { get; set; }

        public string FundType { get; set; }

        public double? OriginalFundAmount { get; set; }

        public double? CurrentFundAmount { get; set; }

        public List <FundForVoucher> fundForVouchers { get; set; }

        public int? FundCriteriaID { get; set; }

        [ForeignKey("FundCriteriaID")]
        public FundCriteria FundCriteria { get; set; }

        public Fund(){}

        public Fund(string fundName, string fundType, double? originalFundAmount)
        {
            this.FundName = fundName;
            this.FundType = fundType;
            this.OriginalFundAmount = originalFundAmount;
            this.CurrentFundAmount = null;
            this.fundForVouchers = new List<FundForVoucher>();
            this.FundCriteriaID = null; 
        }

    }
}
