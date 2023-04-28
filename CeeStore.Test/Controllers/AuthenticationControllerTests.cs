using AutoFixture;
using CeeStore.BLL.ServicesContract;
using CeeStore.Controllers;
using CeeStore.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CeeStore.Test.Controllers
{
    public class AuthenticationControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IAuthenticationService> _mockAuthService;
        private readonly AuthenticationController _authenticationController;

        public AuthenticationControllerTests()
        {
            _fixture = new Fixture();
            _mockAuthService = new Mock<IAuthenticationService>();
            _authenticationController = new AuthenticationController(_mockAuthService.Object);
        }

        

        [Fact]
        public async Task CreateBuyer_ReturnsOkResult_WhenBuyerIsCreatedSuccessfully()
        {
            // Arrange
            var buyer = new BuyerForRegistrationDto
            {
                // Set properties of buyer object here
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Password = "password",
                Email = "johndoe@example.com",
                PhoneNumber = "1234567890",
                Location = "New York"
            };

            var expectedResult = new { success = true };

            _mockAuthService
                .Setup(service => service.RegisterBuyerAsync(It.IsAny<BuyerForRegistrationDto>()))
                ;

            // Act
            var result = await _authenticationController.CreateBuyer(buyer);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedResult, okResult.Value);
        }

        [Fact]
        public async Task CreateBuyer_ReturnsBadRequestResult_WhenBuyerIsNotValid()
        {
            // Arrange
            var buyer = new BuyerForRegistrationDto
            {
                // Set invalid properties of buyer object here
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Password = "password",
                Email = "johndoe@example.com",
                PhoneNumber = "1234567890",
                Location = "New York"
            };

            _authenticationController.ModelState.AddModelError("key", "error message");

            // Act
            var result = await _authenticationController.CreateBuyer(buyer);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateBuyer_ReturnsInternalServerErrorResult_WhenAuthServiceThrowsException()
        {
            // Arrange
            var buyer = new BuyerForRegistrationDto
            {
                // Set properties of buyer object here
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Password = "password",
                Email = "johndoe@example.com",
                PhoneNumber = "1234567890",
                Location = "New York"
            };

            _mockAuthService
                .Setup(service => service.RegisterBuyerAsync(It.IsAny<BuyerForRegistrationDto>()))
                .ThrowsAsync(new Exception("Something went wrong."));

            // Act
            var result = await _authenticationController.CreateBuyer(buyer);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }


    }
}
