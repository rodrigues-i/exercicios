using Clients.API.Repository;
using Clients.API.Models;

using Moq;
using Clients.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Clients.UnitTests.Systems.Controllers;

public class TestUsersControllers
{
    [Fact]
    public async Task GetAll_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var mockIUserRepository = new Mock<IUserRepository>();
        mockIUserRepository
            .Setup(service => service.GetUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockIUserRepository.Object);

        // Act
        var result = await sut.GetAll();

        // Assert
        result.GetType().Should().Be(typeof(OkObjectResult));
        (result as OkObjectResult).StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAll_OnSuccess_Invokes_UserRepository_ExactlyOnce()
    {
        // Arrange
        var mockIUserRepository = new Mock<IUserRepository>();
        mockIUserRepository
            .Setup(service => service.GetUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockIUserRepository.Object);

        // Act
        var result = await sut.GetAll();

        // Assert
        mockIUserRepository.Verify(service => service.GetUsers(), Times.Exactly(1));
    }
}