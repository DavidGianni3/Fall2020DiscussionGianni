using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class Volunteer : ApplicationUser 
    {
        public int NumberOfHoursVolunteered { get; set; }

        public Volunteer(string firstname, string lastname, string address, string phoneNumber, string email, string password, int numberOfHoursVolunteered) :
            base(firstname, lastname, address, phoneNumber, email, password)
        {
            this.NumberOfHoursVolunteered = numberOfHoursVolunteered;
        }

        public Volunteer(){}
    }
}
