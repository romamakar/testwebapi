using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TweetGetter.Controllers;
using TweetGetter.UnitTests.stubs;
using Xunit;

namespace TweetGetter.UnitTests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task Index_ReturnsAViewResult()
        {
            var mock = new Config(new Section());
            var mocklogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mock, mocklogger.Object);
            var result = await controller.Index(new DateTime(2011,01,01), new DateTime(2011, 01, 01)) ;

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<int>(
                viewResult.ViewData.Model);
            Assert.Equal(0, model);
        }
    }
}
