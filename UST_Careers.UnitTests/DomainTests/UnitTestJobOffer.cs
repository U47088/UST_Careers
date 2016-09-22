using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;
using UST_Careers.WebUI.Controllers;
using System.Web.Mvc;
using UST_Careers.WebUI.Models;
using System.Collections.Generic;

namespace UST_Careers.UnitTests.DomainTests
{
    [TestClass]
    public class UnitTestJobOffer
    {
        private Mock<ICategoryRepository> catMock;
        private Mock<ILocationRepository> locMock;
        private IEnumerable<Category> categoriesList { get; set; }
        private IEnumerable<Location> locationsList { get; set; }

        [TestInitialize()]
        public void initInterfaces()
        {
            catMock = new Mock<ICategoryRepository>();
            catMock.Setup(c =>c.Categories).Returns(new Category[] {
                new Category { id = 1, name = "Test" }
            });

            locMock = new Mock<ILocationRepository>();
            locMock.Setup(l => l.Locations).Returns(new Location[] {
                new Location { id = 1, city = "Gdansk", street = "Azymutalna"}
            });

            categoriesList = new List<Category> { new Category { id = 1, name = "test", parent_id = 1 } };
            locationsList = new List<Location> { new Location { id = 1, city = "test" } };
        }
        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange - create mock repository
            Mock<IJobOfferRepository> mock = new Mock<IJobOfferRepository>();
            // Arrange - create the controller
            JobOfferController target = new JobOfferController(mock.Object, locMock.Object, catMock.Object);
            
            // Arrange - create a JobOffer
            JobOffer jobOffer = new JobOffer { title = "Test" };
            JobOfferViewModel viewModel = new JobOfferViewModel(jobOffer, new SelectList(categoriesList, "id", "name"),
                new SelectList(locationsList, "id", "city"));
            // Act - try to save the JobOffer
            ActionResult result = target.Edit(viewModel);
            // Assert - check that the repository was called
            mock.Verify(m => m.SaveJobOffer(jobOffer));
            // Assert - check the method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {

            // Arrange - create mock repository
            Mock<IJobOfferRepository> mock = new Mock<IJobOfferRepository>();
            // Arrange - create the controller
            JobOfferController target = new JobOfferController(mock.Object, locMock.Object, catMock.Object);
            // Arrange - create a JobOffer
            JobOffer jobOffer = new JobOffer { title = "Test" };
            // Arrange - add an error to the model state
            target.ModelState.AddModelError("error", "error");
            // Act - try to save the JobOffer
            JobOfferViewModel viewModel = new JobOfferViewModel(jobOffer, new SelectList(categoriesList, "id", "name"),
                new SelectList(locationsList, "id", "city"));
            ActionResult result = target.Edit(viewModel);
            // Assert - check that the repository was not called
            mock.Verify(m => m.SaveJobOffer(It.IsAny<JobOffer>()), Times.Never());
            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Can_Delete_Valid_JobOffers()
        {
            // Arrange - create a JobOffer
            JobOffer jobOffer = new JobOffer { id = 2, title = "Test" };
            // Arrange - create the mock repository
            Mock<IJobOfferRepository> mock = new Mock<IJobOfferRepository>();
            mock.Setup(m => m.JobOffers).Returns(new JobOffer[] {
                new JobOffer {id = 1, title = "P1"},
                jobOffer,
                new JobOffer {id = 3, title = "P3"},
                });
            // Arrange - create the controller
            JobOfferController target = new JobOfferController(mock.Object, locMock.Object, catMock.Object);
            // Act - delete the JobOffer
            target.Delete(jobOffer.id);
            // Assert - ensure that the repository delete method was
            // called with the correct JobOffer
            mock.Verify(m => m.DeleteJobOffer(jobOffer.id));
        }
    }


}
