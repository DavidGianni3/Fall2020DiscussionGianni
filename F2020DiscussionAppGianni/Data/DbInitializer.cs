using F2020DiscussionAppGianni.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F2020DiscussionAppGianni.Data
{
    class DbInitializer
    {
        //signature of a method? 
        //accessType returnType MethodName(parameterType param1, parameterType param2) number, dataType, order

        //class methods / object or instance methods 
        public static void Initialize(IServiceProvider services)
        {
            //Three services 
            //1. databases
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            //2. Roles
            // In startup.cs
            //.AddRoles<IdentityRole>() on line 34
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //3. Users 
            //In startup.cs (change on line 33: IdentityUser to ApplicationUser)
            //In _LoginPartial.cshtml (change lines 2 and 3 identityUser to ApplicationUser)
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string clientRole = "Client";
            string volunteerRole = "Volunteer";
            string administratorRole = "Administrator"; 


            if(!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(clientRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(volunteerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(administratorRole);
                roleManager.CreateAsync(role).Wait();
            }

            if(!database.ApplicationUser.Any())
            {
                Client client = new Client("Test", "Client1", "1 Client1 Address", "3040000001", "TestClient1@test.com", "TestClient1");
                userManager.CreateAsync(client).Wait();
                userManager.AddToRoleAsync(client, clientRole).Wait();//all async methods need to have the .wait() attached

                client = new Client("Test", "Client2", "2 Client2 Address", "3040000002", "TestClient2@test.com", "TestClient2");
                userManager.CreateAsync(client).Wait();
                userManager.AddToRoleAsync(client, clientRole).Wait();

                Volunteer volunteer = new Volunteer("Test", "Volunteer1", "1 Volunteer1 Address", "3040000003", "TestVolunteer1@test.com", "TestVolunteer1", 10);
                userManager.CreateAsync(volunteer).Wait();
                userManager.AddToRoleAsync(volunteer, volunteerRole).Wait();
                userManager.AddToRoleAsync(volunteer, administratorRole).Wait();

                volunteer = new Volunteer("Test", "Volunteer2", "2 Volunteer2 Address", "3040000004", "TestVolunteer2@test.com", "TestVolunteer2", 10);
                userManager.CreateAsync(volunteer).Wait();
                userManager.AddToRoleAsync(volunteer, volunteerRole).Wait();

                ApplicationUser applicationUser = new ApplicationUser("Test", "Administrator1", "1 Administrator1 Address", "3040000005", "TestAdministrator1@test.com", "TestAdministrator1");
                userManager.CreateAsync(applicationUser).Wait();
                userManager.AddToRoleAsync(applicationUser, administratorRole).Wait(); 
            }

            
            //conditional operators
            //lovical operators: &&, ||, ! (not)  
            //relational: <, >, >=, ==
            if (!database.Pet.Any()) //Does the Pet table have any data in it? yes
            {
                DateTime? dateOfBirth = new DateTime(2015, 6, 15);

                //LINQ's Lambda Expression (C#  Queries) 
                Client client = database.Client.Where(c => c.Email == "TestClient1@test.com").FirstOrDefault(); 

                string clientID = client.Id; 

                Pet pet = new Pet("James", "Dog", "Male", dateOfBirth, "Large", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = null;

                pet = new Pet("Cleo", "Cat", "Female", dateOfBirth, null, clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                client = database.Client.Where(c => c.Email == "TestClient2@test.com").FirstOrDefault();
                clientID = client.Id;

                dateOfBirth = new DateTime(2018, 6, 10);

                pet = new Pet("Chuck", "Dog", "Male", dateOfBirth, "Small", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = new DateTime(2020, 3, 26);

                pet = new Pet("Jamie", "Dog", "Female", dateOfBirth, "Large", clientID);
                database.Pet.Add(pet);
                database.SaveChanges();

                dateOfBirth = new DateTime(2018, 4, 25);

                pet = new Pet("Larry", "Cat", "Male", dateOfBirth, null, clientID);
                database.Pet.Add(pet);
                database.SaveChanges();
            }

            if (!database.VoucherRequest.Any())
            {
                VoucherRequest voucherRequest = new VoucherRequest("Denied", 1);
                voucherRequest.RequestDecisionDate = new DateTime(2020, 10, 04);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest  = new VoucherRequest("Denied", 2);
                voucherRequest.RequestDecisionDate = new DateTime(2020, 10, 10);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Approved", 1);
                voucherRequest.RequestDecisionDate = new DateTime(2020, 10, 09);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Pending", 2);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Pending", 3);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Approved", 4);
                voucherRequest.RequestDecisionDate = new DateTime(2020, 10, 01);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                voucherRequest = new VoucherRequest("Approved", 5);
                voucherRequest.RequestDecisionDate = new DateTime(2020, 10, 29);
                database.VoucherRequest.Add(voucherRequest);
                database.SaveChanges();

                //add five more requests (2 pets - 2 requests (first request was denied) 

            }
            if(!database.Fund.Any())
            {
                Fund fund = new Fund("Any Fund 1", null, 2000);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Cat Fund 1", "Cat", null);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Dog Fund 1", "Dog", 5000);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Male Fund 1", "Male", 900);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Female Fund 1", "Female", 4000);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Large Dog Fund 1", "Large Dog", 500);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Any Fund 7", null, 700);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Any Fund 8", null, 3000);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Any Fund 9", null, 6000);
                database.Fund.Add(fund);
                database.SaveChanges();

                fund = new Fund("Any Fund 10", "Any", null);
                database.Fund.Add(fund);
                database.SaveChanges();

            }
            if (!database.FundCriteria.Any())
            {
                int fundID = 2;
                FundCriteria fundCriteria = new FundCriteria(fundID, "Morgantown", null, null, "Cat");
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                Fund fund = database.Fund.Find(fundID);
                fund.FundCriteriaID = 1;
                database.Fund.Update(fund);
                database.SaveChanges();

                fundID = 3;
                fundCriteria = new FundCriteria(fundID, "Morgantown", null, null, "Dog");
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                fund = database.Fund.Find(fundID);
                fund.FundCriteriaID = 2;
                database.Fund.Update(fund);
                database.SaveChanges();

                fundID = 4;
                fundCriteria = new FundCriteria(fundID, "Morgantown", "Male", null, null);
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                fund = database.Fund.Find(fundID);
                fund.FundCriteriaID = 3;
                database.Fund.Update(fund);
                database.SaveChanges();

                fundID = 5;
                fundCriteria = new FundCriteria(fundID, "Morgantown", "Female", null, null);
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                fund = database.Fund.Find(fundID);
                fund.FundCriteriaID = 4;
                database.Fund.Update(fund);
                database.SaveChanges();

                fundID = 6;
                fundCriteria = new FundCriteria(fundID, "Morgantown", null, "Large", "Dog");
                database.FundCriteria.Add(fundCriteria);
                database.SaveChanges();

                fund = database.Fund.Find(fundID);
                fund.FundCriteriaID = 5;
                database.Fund.Update(fund);
                database.SaveChanges();

            }
            if (!database.FundForVoucher.Any())
            {
                FundForVoucher fundForVoucher = new FundForVoucher(3, 6, 100);
                database.FundForVoucher.Add(fundForVoucher);
                database.SaveChanges();

                fundForVoucher = new FundForVoucher(6, 6, 100);
                database.FundForVoucher.Add(fundForVoucher);
                database.SaveChanges();

                fundForVoucher = new FundForVoucher(7, 2, 50);
                database.FundForVoucher.Add(fundForVoucher);
                database.SaveChanges();
            }


        }//end initialize method

    }//end DbInitializer class

}//end namespace
