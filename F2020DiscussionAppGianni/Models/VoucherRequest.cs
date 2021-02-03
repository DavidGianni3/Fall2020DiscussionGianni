using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class VoucherRequest
    {
        [Key]
        public int RequestID { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string RequestStatus { get; set; }
        public DateTime? RequestDecisionDate { get; set; }
        public double? RequestAmount { get; set; }//What is the initial value? null - no decision
        public bool? VoucherRedeemed { get; set; }//What is the initial value? null 
        [Required]
        public int PetID { get; set; } //column that serves as FK (relational database)
       
        //object oriented connection 
        [ForeignKey("PetID")]
        public Pet RequestForPet { get; set; }

        public List<FundForVoucher> fundForVouchers { get; set; }

        //when you create a constructor with parameters, you also need another constructor that is empty. 
        public VoucherRequest(string RequestStatus, int PetID)
        {
            this.RequestDate = DateTime.Today.Date;
            this.RequestStatus = RequestStatus;
            this.PetID = PetID;
            this.RequestDecisionDate = null;
            this.RequestAmount = null;
            this.VoucherRedeemed = null;
            this.fundForVouchers = new List<FundForVoucher>();
        }
        public VoucherRequest(){}
    }
}
