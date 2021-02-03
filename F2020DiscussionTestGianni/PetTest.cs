using System;
using Xunit;
using F2020DiscussionAppGianni.Controllers;
using F2020DiscussionAppGianni.Data;
using Moq;
using System.Collections.Generic;
using F2020DiscussionAppGianni.Models;
using Microsoft.AspNetCore.Mvc;

namespace F2020DiscussionTestGianni
{
    public class PetTest
    {
        //instance variable
        private Mock<IPetRepo> mockPetRepo;

        [Fact]
        public void ShouldAddNewPet()//Happy path
        {

        }
        [Fact]
        public void ShouldNotAddNewPet()//Sad path
        {

        }

        [Fact]
        public void ShouldListAllPets()
        {
            //AAA
            //1. Arrange
            //ApplicationDbContext database = null; (Controller does not use / depend on database)
            
            mockPetRepo = new Mock<IPetRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets);

            int expectedNumberOfPetsInList = 4;

            PetController petController = new PetController(mockPetRepo.Object);//database);

            //2. Action

            ViewResult result = petController.ListAllPets() as ViewResult; //I know that the resulting datatype is a  viewresult (casting) 
            List<Pet> resultModel = result.Model as List<Pet>;
            int actualNumberOfPetsInList = resultModel.Count;

            //3. Assert (comparing: Expecting v Actual) 

            Assert.Equal(expectedNumberOfPetsInList, actualNumberOfPetsInList);

        }

        //Create (Add) / Read (List All, Search, Get / find One Object) / Update (Modify) / Delete (Remove) 

        //Client / Pete Owner, PetType, Decisiondate (start date, end date): all optional 

        //try: requeststatus (pending / approved / denied ) , voucherRedeemed? 

        [Fact]
        public void ShouldSearchForPetsByOwner()
        {
            //AAA
            //1. Arrange
            mockPetRepo = new Mock<IPetRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //Logic will be in the controller method

            mockPetRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumberOfPetsInList = 2;

            PetController petController = new PetController(mockPetRepo.Object);

            //DropDownList for owners [Text = Full name of the owner ? Value = Id]
            string clientID = "001";
            string petType = null;
            DateTime? startDate = null;
            DateTime? endDate = null;

            SearchForPetsViewModel viewModel = new SearchForPetsViewModel();
            viewModel.ClientID = clientID;
            viewModel.PetType = petType;
            viewModel.StartDate = startDate;
            viewModel.EndDate = endDate;
            viewModel.UserFirstVisit = "No";
            
            //2. Act
            ViewResult result = petController.SearchForPets(viewModel) as ViewResult;
            SearchForPetsViewModel resultModel = result.Model as SearchForPetsViewModel;
            int actualNumberOfPetsInList = resultModel.ResultPetList.Count;

            //3. Assert
            Assert.Equal(expectedNumberOfPetsInList, actualNumberOfPetsInList);

        }

        [Fact]
        public void ShouldSearchForPetsByOwnerAndPetType()
        {
            //AAA
            //1. Arrange
            mockPetRepo = new Mock<IPetRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //Logic will be in the controller method

            mockPetRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumberOfPetsInList = 1;

            PetController petController = new PetController(mockPetRepo.Object);

            //DropDownList for owners [Text = Full name of the owner ? Value = Id]
            string clientID = "002";
            string petType = "Dog";
            DateTime? startDate = null;
            DateTime? endDate = null;

            SearchForPetsViewModel viewModel = new SearchForPetsViewModel();
            viewModel.ClientID = clientID;
            viewModel.PetType = petType;
            viewModel.StartDate = startDate;
            viewModel.EndDate = endDate;
            viewModel.UserFirstVisit = "No";

            //2. Act
            ViewResult result = petController.SearchForPets(viewModel) as ViewResult;
            SearchForPetsViewModel resultModel = result.Model as SearchForPetsViewModel;
            int actualNumberOfPetsInList = resultModel.ResultPetList.Count;

            //3. Assert
            Assert.Equal(expectedNumberOfPetsInList, actualNumberOfPetsInList);

        }

        [Fact]
        public void ShouldSearchForPetsByARangeOfDecisionDates()
        {
            //AAA
            //1. Arrange
            mockPetRepo = new Mock<IPetRepo>();

            List<Pet> mockPets = CreateMockPetData();
            mockPetRepo.Setup(m => m.ListAllPets()).Returns(mockPets); //Logic will be in the controller method

            mockPetRepo.Setup(m => m.ListAllClients()).Returns(new List<Client>());

            int expectedNumberOfPetsInList = 3;

            PetController petController = new PetController(mockPetRepo.Object);

            //DropDownList for owners [Text = Full name of the owner ? Value = Id]
            string clientID = null;
            string petType = null;
            DateTime? startDate = new DateTime(2020,10,1);
            DateTime? endDate = new DateTime(2020,10,31);

            SearchForPetsViewModel viewModel = new SearchForPetsViewModel();
            viewModel.ClientID = clientID;
            viewModel.PetType = petType;
            viewModel.StartDate = startDate;
            viewModel.EndDate = endDate;
            viewModel.UserFirstVisit = "No";

            //2. Act
            ViewResult result = petController.SearchForPets(viewModel) as ViewResult;
            SearchForPetsViewModel resultModel = result.Model as SearchForPetsViewModel;
            int actualNumberOfPetsInList = resultModel.ResultPetList.Count;

            //3. Assert
            Assert.Equal(expectedNumberOfPetsInList, actualNumberOfPetsInList);

        }

        



        //helper method
        public List<Pet> CreateMockPetData()
        {
            List<Pet> mockPets = new List<Pet>();

            string testClientID = "001";
            DateTime? petDateOfBirth = null;

            Pet pet = new Pet("Test Dog 1", "Dog", "Male", petDateOfBirth, "Large", testClientID);
            pet.PetID = 1; 
            

            DateTime decisionDate = new DateTime(2020,10,1);

            VoucherRequest voucherRequest = new VoucherRequest("Denied", 1);
            voucherRequest.RequestDecisionDate = decisionDate;
            pet.VoucherRequestsForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            voucherRequest = new VoucherRequest("Pending", 1);
            pet.VoucherRequestsForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            mockPets.Add(pet);

            petDateOfBirth = new DateTime(2015, 11, 10);

            pet = new Pet("Test Dog 2", "Dog", "Female", petDateOfBirth, "Medium", testClientID);
            pet.PetID = 2;

            decisionDate = new DateTime(2020, 10, 15);

            voucherRequest = new VoucherRequest("Denied", 2);
            voucherRequest.RequestDecisionDate = decisionDate;
            pet.VoucherRequestsForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            decisionDate = new DateTime(2020, 11, 25);

            voucherRequest = new VoucherRequest("Approved", 2);
            voucherRequest.RequestDecisionDate = decisionDate;
            pet.VoucherRequestsForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            mockPets.Add(pet);

            petDateOfBirth = new DateTime(2018, 10, 15);
            testClientID = "002";

            

            pet = new Pet("Test Cat 1", "Cat", "Female", petDateOfBirth, null, testClientID);
            pet.PetID = 3; 

            decisionDate = new DateTime(2020, 10, 15);

            voucherRequest = new VoucherRequest("Denied", 3);
            voucherRequest.RequestDecisionDate = decisionDate;
            pet.VoucherRequestsForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            mockPets.Add(pet);

            pet = new Pet("Test Dog 3", "Dog", "Female", petDateOfBirth, "Medium", testClientID);
            pet.PetID = 4; 

            decisionDate = new DateTime(2020, 11, 25);

            voucherRequest = new VoucherRequest("Approved", 2);
            voucherRequest.RequestDecisionDate = decisionDate;
            pet.VoucherRequestsForPet.Add(voucherRequest);
            voucherRequest.RequestForPet = pet;

            mockPets.Add(pet);

            return mockPets;
        }
    }
}
