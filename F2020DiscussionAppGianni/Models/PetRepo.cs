using F2020DiscussionAppGianni.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public class PetRepo : IPetRepo
    {
        private ApplicationDbContext database; 

        //dependency injection
        public PetRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
            
        }

        public List<Client> ListAllClients()
        {
            List<Client> clients = database.Client.ToList();
            return clients; 
        }

        public List<Pet> ListAllPets()
        {
            List<Pet> pets = database.Pet.Include(p => p.Client).Include(p => p.VoucherRequestsForPet).ToList();
            return pets;
        }

        
    }
}
