using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppGianni.Models
{
    public interface IPetRepo
    {
        //List of method signatures 
        //Promises what should be done, but not how (not implemented here) 
        List<Pet> ListAllPets();

        List<Client> ListAllClients();
    }
}
