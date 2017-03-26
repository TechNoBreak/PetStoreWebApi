using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Controllers;
using PetStore.Models;
using PetStore.Repositories;
using System.Web.Http;
using System.Web;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using Moq;

namespace PetStore.Tests
{
    [TestClass]
    public class TestPetsController
    {

        //Test to make sure returned pet has right id
        [TestMethod]
        public void PetHasRightId()
        {
            var mockRepo = new Mock<IPetStoreRepository>();
            mockRepo.Setup(x => x.FindById(4))
                .Returns(new Pet { Id = 4 });

            var controller = new PetsController(mockRepo.Object);

            IHttpActionResult actionResult = controller.GetPet(4);
            var contentResult = actionResult as OkNegotiatedContentResult<Pet>;

        
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(4, contentResult.Content.Id);           
        }


        //Test to check return type is NotFoundResult
        [TestMethod]
        public void PetGetReturnsNotFound()
        {
            var mockRepo = new Mock<IPetStoreRepository>();
            var controller = new PetsController(mockRepo.Object);
            IHttpActionResult actionResult = controller.GetPet(3);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        //Test to check return type is Ok Result
        [TestMethod]
        public void PetDeleteReturnsOk()
        {            
            var mockRepo = new Mock<IPetStoreRepository>();
            var controller = new PetsController(mockRepo.Object);
           
            IHttpActionResult actionResult = controller.DeletePet(4);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
         
        }


        //Test to check that the action sets the correct routing values.
        [TestMethod]
        public void PetPostSetsLocationHeader()
        {
            var mockRepo = new Mock<IPetStoreRepository>();
            var controller = new PetsController(mockRepo.Object);
            IHttpActionResult actionResult = controller.PostPet(new Pet { Id = 10, Name = "Kitty", Category = "White", IsAvailable = true, PhotoUrl = "" });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Pet>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(10, createdResult.RouteValues["id"]);
        }

    }



}
