using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using zakjr.Controllers;
using zakjr.Data;

namespace zakjr.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task IndexActionReturnsAView()
        {
            // Arrange
            var moqDbContext = new Mock<ApplicationDbContext>();
            var homeController = new HomeController(moqDbContext.Object);

            // Act
            ViewResult viewResult = await homeController.Index() as ViewResult;

            // Assert
            Assert.NotNull(viewResult);
        }

        [Fact]
        public async Task IndexActionContentInSequence()
        {
            // Arrange
            var moqDbContext = new Mock<ApplicationDbContext>();
            var homeController = new HomeController(moqDbContext.Object);

            // Act
            ViewResult viewResult = await homeController.Index() as ViewResult;

            // Assert
            


            throw new NotImplementedException();
        }
    }
}
