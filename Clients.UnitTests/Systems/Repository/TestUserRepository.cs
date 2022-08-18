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

    }
}