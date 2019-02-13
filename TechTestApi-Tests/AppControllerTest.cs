using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestApi.Controllers;
using Xunit;

namespace TechTestApi_Tests
{
    public class AppControllerTest
    {
        AppController _controller;

        public AppControllerTest()
        {
            _controller = new AppController();
        }

        [Fact]
        public void Root_WhenCalled_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetAppRoot();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull((result as OkObjectResult).Value);
        }

        [Fact]
        public void Health_WhenCalledWithNullStatus_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetAppHealth(null) as NotFoundObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public void Health_WhenCalledWithStatus_ReturnsAppropiateResult()
        {
            // Act
            var okResult = _controller.GetAppHealth("OK") as OkObjectResult;
            var badResult = _controller.GetAppHealth("BaD") as BadRequestObjectResult;
            var errordResult = _controller.GetAppHealth("error") as ObjectResult;
            var pirateResult = _controller.GetAppHealth("Pirate") as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode);
            Assert.Equal(StatusCodes.Status500InternalServerError, errordResult.StatusCode);
            Assert.Equal(StatusCodes.Status401Unauthorized, pirateResult.StatusCode);
        }

        [Fact]
        public void Info_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAppInfo();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.NotNull((result as JsonResult).Value);
        }
    }
}
