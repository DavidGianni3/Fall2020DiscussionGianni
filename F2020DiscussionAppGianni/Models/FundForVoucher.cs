using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    //
    public class FundForVoucher
    {
        [Key]
        public int FundForVoucherID { get; set; }

        [Required]
        public double AmountAssigned { get; set; }

        //Relational database connection (FK) 
        [Required]
        public int RequestID { get; set; }

        [Required]
        public int FundID { get; set; }

        //object oriented connections - Tell EF -> I already created FK connections

        [ForeignKey("RequestID")]
        public VoucherRequest VoucherRequest { get; set; }

        [ForeignKey("FundID")]
        public Fund Fund { get; set; }

        public FundForVoucher(){}
        public FundForVoucher(int requestID, int fundID, double amountAssigned)
        {
            this.RequestID = requestID;
            this.FundID = fundID;
            this.AmountAssigned = amountAssigned;
        }

    }
}
