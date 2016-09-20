using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;
using UST_Careers.WebUI.Controllers;
using System.Web.Mvc;

namespace UST_Careers.UnitTests.DomainTests
{
    [TestClass]
    public class UnitTestJobOffer
    {
        [TestMethod]
        public void Can_Edit_JobOffer()
        {
            // Arrange - create the mock repository
            Mock<IJobOfferRepository> mock = new Mock<IJobOfferRepository>();
            mock.Setup(m => m.JobOffers).Returns(new JobOffer[] {
                new JobOffer {id = 1, title = "P1"},
                new JobOffer {id=  2, title = "P2"},
                new JobOffer {id = 3, title = "P3"},
                });
            // Arrange - create the controller
            JobOfferController target = new JobOfferController(mock.Object);
            // Act
            JobOffer p1 = target.Edit(1).ViewData.Model as JobOffer;
            JobOffer p2 = target.Edit(2).ViewData.Model as JobOffer;
            JobOffer p3 = target.Edit(3).ViewData.Model as JobOffer;
            // Assert
            Assert.AreEqual(1, p1.id);
            Assert.AreEqual(2, p2.id);
            Assert.AreEqual(3, p3.id);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_JobOffer()
        {
            // Arrange - create the mock repository
            Mock<IJobOfferRepository> mock = new Mock<IJobOfferRepository>();
            mock.Setup(m => m.JobOffers).Returns(new JobOffer[] {
                new JobOffer {id = 1, title = "P1"},
                new JobOffer {id = 2, title = "P2"},
                new JobOffer {id = 3, title = "P3"},
                });
            // Arrange - create the controller
            JobOfferController target = new JobOfferController(mock.Object);
            // Act
            JobOffer result = (JobOffer)target.Edit(4).ViewData.Model;
            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange - create mock repository
            Mock<IJobOfferRepository> mock = new Mock<IJobOfferRepository>();
            // Arrange - create the controller
            JobOfferController target = new JobOfferController(mock.Object);
            // Arrange - create a JobOffer
            JobOffer jobOffer = new JobOffer { title = "Test" };
            // Act - try to save the JobOffer
            ActionResult result = target.Edit(jobOffer);
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
            JobOfferController target = new JobOfferController(mock.Object);
            // Arrange - create a JobOffer
            JobOffer jobOffer = new JobOffer { title = "Test" };
            // Arrange - add an error to the model state
            target.ModelState.AddModelError("error", "error");
            // Act - try to save the JobOffer
            ActionResult result = target.Edit(jobOffer);
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
            JobOfferController target = new JobOfferController(mock.Object);
            // Act - delete the JobOffer
            target.Delete(jobOffer.id);
            // Assert - ensure that the repository delete method was
            // called with the correct JobOffer
            mock.Verify(m => m.DeleteJobOffer(jobOffer.id));
        }
    }


}
