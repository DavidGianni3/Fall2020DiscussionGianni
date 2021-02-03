using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class Client : ApplicationUser
    {
        //Object-oriented connection to each client's Pets
        public List<Pet> ClientPets { get; set; }

        public Client(string firstname, string lastname, string address, string phoneNumber, string email, string password):
            base(firstname, lastname, address, phoneNumber, email, password)
        {
            this.ClientPets = new List<Pet>();
        }

        public Client(){}

    }//end Client Class
}
