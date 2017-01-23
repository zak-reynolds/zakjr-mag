using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using zakjr.Controllers;
using zakjr.Data;

namespace zakjr_mag.Tests
{
    public class TestExample
    {

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(1, 1);
        }
        [Theory]
        [InlineData(2)]
        public void IsTwoTheory(int value)
        {
            Assert.Equal(2, value);
        }
        // TODO: Learn how to use Moq or some kind of mocking framework properly
        //[Fact]
        //public async Task HomeControllerIndexActionReturnsAView()
        //{
        //    DbContextOptions<BlogContext> o = new DbContextOptions<BlogContext>();
        //    BlogContext bc = new BlogContext(o);
        //    HomeController hc = new HomeController(bc);
        //    var result = await hc.Index();
        //    Assert.NotNull(result);
        //}
    }
}
