using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class SearchForPetsViewModel
    {
        //properties for each user input 
        public string ClientID { get; set; }

        public string PetType { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string UserFirstVisit { get; set; }

        //property for result 
        public List<Pet> ResultPetList { get; set; }

    }
}
