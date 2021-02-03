using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class Pet
    {
        //OO <--> Relational Database (Object Relational Mapper: ORM)
        //Entity Framework (EF) component in the library that will do the conversion 

        //Create properties (public), not attributes (private) 
        //attribute
        //private int petID
        //Property

        [Key]
        public int PetID { get; set; }
        public string PetName { get; set; }
        
        [Required]
        public string PetType { get; set; }
        [Required]
        public string PetGender { get; set; }
        //strings accept null values. DateTime doesn't. Nullable DateTime.  
        public DateTime? PetDateOfBirth { get; set; }
        public string PetSize { get; set; }

        [Required]
        public string ClientID { get; set; }
        //object oriented connection 
        [ForeignKey("ClientID")]
        public Client Client { get; set; } // tranlsation from OO to relational database (EF) 


        //this is the object-oriented connection going from pet to VoucherRequest
        public List<VoucherRequest> VoucherRequestsForPet { get; set; }

        //foreign key to client (Client's name) 

        //2 constructors
        //one with parameters (create a constructor with parameters)
        //second one with no parameters (empty constructor) 
        public Pet(){}
        public Pet(string petName, string petType, string petGender, DateTime? petDateOfBirth, string petSize, string clientID)
        {
            this.PetName = petName;
            this.PetType = petType;
            this.PetGender = petGender;
            this.PetDateOfBirth = petDateOfBirth;
            this.PetSize = petSize;
            this.ClientID = clientID;
            this.VoucherRequestsForPet = new List<VoucherRequest>();


        }
    }
}
