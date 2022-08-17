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
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUsers())
            .ReturnsAsync(new List<User>() {
                new User {
                    id = Guid.NewGuid(),
                    firstName = "Gustavo",
                    surname = "Lima",
                    age = 15,
                    creationDate = DateTime.Now
                }
            });

        var sut = new UsersController(mockUserRepository.Object);

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
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.GetAll();

        // Assert
        mockUserRepository.Verify(service => service.GetUsers(), Times.Exactly(1));
    }

    [Fact]
    public async Task GetAll_OnSuccess_ReturnsListOfUser()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUsers())
            .ReturnsAsync(new List<User>() {
                new User {
                    id = Guid.NewGuid(),
                    firstName = "Gustavo",
                    surname = "Lima",
                    age = 15,
                    creationDate = DateTime.Now
                }});

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.GetAll();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task GetAll_OnNoUsersFound_ReturnsStatusCode404()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.GetAll();
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}