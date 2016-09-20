using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;
using UST_Careers.WebUI.Controllers;

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
        public void Cannot_Edit_Nonexistent_Product()
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
    }
}
