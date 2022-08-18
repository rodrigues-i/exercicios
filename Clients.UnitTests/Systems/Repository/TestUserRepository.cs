using Clients.API.Data;
using Clients.API.Models;
using Clients.API.Repository;
using Clients.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Clients.UnitTests.Systems.Repository
{
    public class TestUserRepository
    {
        private readonly DataContext _context;

        public TestUserRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            _context = new DataContext(optionsBuilder.Options);
        }

        [Fact]
        public async Task AddUser_ShouldAddNewUser()
        {
            // Arrange
            var mockUsers = UsersFixture.GetTestUsers();
            _context.Users.AddRange(mockUsers);
            _context.SaveChanges();

            var sut = new UserRepository(_context);

            // Act
            var result = await sut.GetUsers();

            // Assert
            result.Should().HaveCount(mockUsers.Count);
            result.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task GetUserById_ShouldReturn_User_Object()
        {
            // Arrange
            var mockUsers = UsersFixture.GetTestUsers();
            _context.Users.AddRange(mockUsers);
            _context.SaveChanges();

            var mockUser = mockUsers[0];
            var sut = new UserRepository(_context);

            // Act
            var result = await sut.GetUserById(mockUser.id);

            // Assert
            result.Should().BeOfType<User>();
        }

        [Fact]
        public async Task AddUser_Should_AddUser()
        {
            // Arrange
            var mockUsers = UsersFixture.GetTestUsers();
            _context.Users.AddRange(mockUsers);
            _context.SaveChanges();

            var expectedCount = mockUsers.Count + 1;

            var newUser = UsersFixture.GetTestUser(Guid.NewGuid());

            var sut = new UserRepository(_context);

            // Act
            sut.AddUser(newUser);
            await sut.SaveChangesAsync();

            // Assert
            _context.Users.Count().Should().Be(expectedCount);
        }

        [Fact]
        public async Task UpdateUser_ShouldUpdate_AnUser()
        {
            // Arrange
            var mockUsers = UsersFixture.GetTestUsers();
            _context.Users.AddRange(mockUsers);
            _context.SaveChanges();

            var userToBeModified = mockUsers[1];
            var originalAge = userToBeModified.age;

            // Act
            var sut = new UserRepository(_context);
            var DbUser = await sut.GetUserById(userToBeModified.id);

            DbUser.age = 68;
            sut.UpdateUser(DbUser);
            await sut.SaveChangesAsync();

            // Assert
            var user = await sut.GetUserById(DbUser.id);
            var currentAge = user.age;

            currentAge.Should().NotBe(originalAge);
        }

        [Fact]
        public async Task DeleteUser_ShouldRemoveUser()
        {
            // Arrange 
            var mockUsers = UsersFixture.GetTestUsers();
            _context.Users.AddRange(mockUsers);
            _context.SaveChanges();

            var userToBeDelete = mockUsers[0];

            var expectedCount = mockUsers.Count - 1;
            var sut = new UserRepository(_context);

            // Act
            sut.DeleteUser(userToBeDelete);
            await sut.SaveChangesAsync();

            _context.Users.Count().Should().Be(expectedCount);
        }
    }
}