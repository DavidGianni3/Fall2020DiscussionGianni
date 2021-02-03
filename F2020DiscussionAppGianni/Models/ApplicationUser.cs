using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace F2020DiscussionAppGianni.Models
{
    public class ApplicationUser : IdentityUser 
    {
        //1. Primary key is ID. Pre-exists, so don't create an Id property
        //2. Id is a string. 

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public string Fullname
        {
            get { return (Firstname + " " + Lastname); }
        }
        [Required]
        public string Address { get; set; }

        public ApplicationUser(){}

        public ApplicationUser(string firstname, string lastname, string address, string phoneNumber, string email, string password)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.UserName = email;
            //password has to be hashed (cannot be clear text) 
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            this.PasswordHash = passwordHasher.HashPassword(this, password);
            //GUID - Globally Unique Identifier 
            this.SecurityStamp = Guid.NewGuid().ToString(); 
        }

    } //end class
}//end name space 
