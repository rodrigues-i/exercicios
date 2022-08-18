using System;
using Clients.API.Repository;
using Clients.API.Models;

using Moq;
using Clients.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Clients.UnitTests.Fixtures;

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
            .ReturnsAsync(UsersFixture.GetTestUsers());

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
            .ReturnsAsync(UsersFixture.GetTestUsers());

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

    [Fact]
    public async Task Get_OnSuccess_ReturnsAUser()
    {
        // Arrange
        var userGuid = Guid.NewGuid();
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUserById(userGuid))
            .ReturnsAsync(UsersFixture.GetTestUser(userGuid));
        
        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Get(userGuid);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        
        var objectResult = (OkObjectResult)result;
        objectResult.StatusCode.Should().Be(200);
        objectResult.Value.Should().BeOfType<User>();
    }

    [Fact]
    public async Task Get_OnNoUserFound_ReturnsStatusCode404()
    {
        // Arrange
        var userGuid = Guid.NewGuid();
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUserById(userGuid))
            .ReturnsAsync(() => null);

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Get(userGuid);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
        var objectResult = (NotFoundObjectResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Create_OnSuccess_CreatesNewUser()
    {
        // Arrange
        var newUser = UsersFixture.GetTestUser(Guid.NewGuid());
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.AddUser(newUser));
        mockUserRepository
            .Setup(service => service.SaveChangesAsync())
            .ReturnsAsync(true);
        
        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Create(newUser);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult) result;
        objectResult.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Create_OnSuccess_InokesAddUser()
    {
        // Arrange
        var newUser = UsersFixture.GetTestUser(Guid.NewGuid());
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.AddUser(newUser));

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        await sut.Create(newUser);

        // Assert
        mockUserRepository.Verify(service => service.AddUser(newUser), Times.Once());
    }

    [Fact]
    public async Task Create_OnUserWithoutFirstName_ReturnsStatusCode400()
    {
        // Arrange
        var newUser = UsersFixture.GetTestUserWithoutFirstName();
        var mockUserRepository = new Mock<IUserRepository>();
        
        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Create(newUser);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var objectResult = (BadRequestObjectResult)result;
        objectResult.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Create_OnUserWithAgeZero_ReturnsStatusCode400()
    {
        // Arrange
        var newUser = UsersFixture.GetTestUserWithAgeZero();
        var mockUserRepository = new Mock<IUserRepository>();

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Create(newUser);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var objectResult = (BadRequestObjectResult)result;
        objectResult.StatusCode.Should().Be(400);
        
    }

    [Fact]
    public async Task Create_OnSuccess_InvokesRepositorySaveChangesAsync()
    {
        // Arrange
        var newUser = UsersFixture.GetTestUser(Guid.NewGuid());
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.AddUser(newUser));
        
        var sut = new UsersController(mockUserRepository.Object);

        // Act
        await sut.Create(newUser);

        // Assert
        mockUserRepository.Verify(service => service.SaveChangesAsync(), Times.Exactly(1));
    }

    [Fact]
    public async Task Update_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var userGuid = Guid.NewGuid();
        var newUser = UsersFixture.GetTestUser(userGuid);
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUserById(userGuid))
            .ReturnsAsync(UsersFixture.GetTestUsers()[0]);
        mockUserRepository
            .Setup(service => service.UpdateUser(newUser));
        mockUserRepository
            .Setup(service => service.SaveChangesAsync())
            .ReturnsAsync(true);

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Update(userGuid, newUser);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_OnUserWithoutFirstName_ReturnStatusCode400()
    {
        var userGuid = Guid.NewGuid();
        var newUser = UsersFixture.GetTestUserWithoutFirstName();
        var mockUserRepository = new Mock<IUserRepository>();

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Update(userGuid, newUser);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var objectResult = (BadRequestObjectResult)result;
        objectResult.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Update_OnUserWithAgeZero_ReturnsStatusCode400()
    {
        // Arrange
        var userGuid = Guid.NewGuid();
        var newUser = UsersFixture.GetTestUserWithAgeZero();
        var mockUserRepository = new Mock<IUserRepository>();

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Update(userGuid, newUser);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var objectResult = (BadRequestObjectResult)result;
        objectResult.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Update_OnNoUserFound_ReturnsStatusCode400()
    {
        // Arrange
        var userGuid = Guid.NewGuid();
        var newUser = UsersFixture.GetTestUser(userGuid);
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUserById(userGuid))
            .ReturnsAsync(() => null);

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        var result = await sut.Update(userGuid, newUser);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var objectResult = (BadRequestObjectResult)result;
        objectResult.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Update_OnSuccess_InvokesRepositoryUpdateUser()
    {
         // Arrange
        var newUser = UsersFixture.GetTestUsers()[0];
        var userGuid = newUser.id;
        
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUserById(userGuid))
            .ReturnsAsync(newUser);
        mockUserRepository
            .Setup(service => service.UpdateUser(newUser));
        
        var sut = new UsersController(mockUserRepository.Object);

        // Act
        await sut.Update(userGuid, newUser);

        // Assert
        mockUserRepository.Verify(service => service.UpdateUser(newUser), Times.Exactly(1));
    }

    [Fact]
    public async Task Update_OnSuccess_InvokesSaveChangesAsync()
    {
        // Arrange
        var newUser = UsersFixture.GetTestUsers()[0];
        var userGuid = newUser.id;

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(service => service.GetUserById(userGuid))
            .ReturnsAsync(newUser);
        mockUserRepository
            .Setup(service => service.UpdateUser(newUser));
        mockUserRepository
            .Setup(service => service.SaveChangesAsync())
            .ReturnsAsync(true);

        var sut = new UsersController(mockUserRepository.Object);

        // Act
        await sut.Update(userGuid, newUser);

        // Assert
        mockUserRepository.Verify(service => service.SaveChangesAsync(), Times.Once());

    }
}