using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class FundCriteria
    {
        //create all the properties
        //populate with 5 rows 

        [Key]
        public int FundCriteriaID { get; set; }

        [Required]
        public int FundID { get; set; }

        [ForeignKey("FundID")]
        public Fund CriteriaForFund { get; set; }

        public string ClientLocation { get; set; } // county where client lives

        public string PetGender { get; set; }

        public string PetSize { get; set; }

        public string PetType { get; set; }

        public FundCriteria(){}

        public FundCriteria(int fundID, string clientLocation, string petGender, string petSize, string petType)
        {
            this.FundID = fundID;
            this.ClientLocation = clientLocation;
            this.PetGender = petGender;
            this.PetSize = petSize;
            this.PetType = petType;
        }
    }
}
