using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F2020DiscussionAppGianni.Data;
using F2020DiscussionAppGianni.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace F2020DiscussionAppGianni.Controllers
{
    public class PetController : Controller
    {
        //separation of concerns 
        //M - data layer (database) 
        //C - business Logic 
        //V - UI
        
        //Controller <-> database 
        //UI (View) <-> controller 

         

        //instance variable
        //attribute 
        //private ApplicationDbContext database; (replace dependency on database by using interface object)
        private IPetRepo iPetRepo;

        //dependency injection
        public PetController(IPetRepo petRepo) //(ApplicationDbContext dbContext)
        {
            //this.database = dbContext;
            this.iPetRepo = petRepo;
        }

        //User Interface 

        //Interface - Class 
        [Authorize(Roles = "Volunteer, Administrator")]
        public IActionResult ListAllPets()  //build and then right click ListAllPets() and then add View. Razor View not empty 
        {
            //SQL equivalent: select * from Pet; 
            //Doing a join between Pet and VR
            List<Pet> allPets = iPetRepo.ListAllPets(); //database.Pet.Include(p => p.VoucherRequestsForPet).ToList();

            return View(allPets);
        }

        /*
        public IActionResult SearchForPetsUserInput()
        {
            //Dynamic drop down list (Clients from database)

            ViewData["AllClients"] = new SelectList(iPetRepo.ListAllClients(),"Id" , "Fullname"); //list of items, Value, Text

            SearchForPetsViewModel searchForPetsViewModel = new SearchForPetsViewModel();

            return View(searchForPetsViewModel); 
        }
        */
        
        public IActionResult SearchForPets (SearchForPetsViewModel viewModel)
            
            //(string clientID, string petType, DateTime? startDate, DateTime? endDate)
        {

            ViewData["AllClients"] = new SelectList(iPetRepo.ListAllClients(), "Id", "Fullname");

            //is this the first time the user has visited this view? 

            List<Pet> searchList;

            if (viewModel.UserFirstVisit != "No")
            {
                searchList = null;
            }
            else
            {
                searchList = iPetRepo.ListAllPets();


                if (!string.IsNullOrEmpty(viewModel.ClientID))
                {
                    searchList = searchList.Where(p => p.ClientID == viewModel.ClientID).ToList();
                }


                if (!String.IsNullOrEmpty(viewModel.PetType))
                {
                    searchList = searchList.Where(p => p.PetType == viewModel.PetType).ToList();
                }

                if (viewModel.StartDate.HasValue)
                {
                    searchList = searchList.Where(p => p.VoucherRequestsForPet.Any(vr => vr.RequestDecisionDate >= viewModel.StartDate.Value.Date)).ToList();
                }

                //return View(searchList);

                if (viewModel.EndDate.HasValue)
                {
                    searchList = searchList.Where(p => p.VoucherRequestsForPet.Any(vr => vr.RequestDecisionDate <= viewModel.EndDate.Value.Date)).ToList();
                }
            }

            //1. create an object of the SearchForPetsViewModel  (use the parameter object) 
            //SearchForPetsViewModel searchForPetsViewModel = new SearchForPetsViewModel();
            //2. Assign
            viewModel.ResultPetList = searchList; 

            return View(viewModel);


        }
    }
}
