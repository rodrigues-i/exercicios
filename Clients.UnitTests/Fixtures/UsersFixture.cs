using Clients.API.Models;

namespace Clients.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new() {
                new User {
                    Id = Guid.NewGuid(),
                    FirstName = "João",
                    Surname = "Silva",
                    Age = 28,
                    CreationDate = DateTime.Now
                },
                new User {
                    Id = Guid.NewGuid(),
                    FirstName = "Pedro",
                    Surname = "Oliveira",
                    Age = 56,
                    CreationDate = DateTime.Now
                },
                new User {
                    Id = Guid.NewGuid(),
                    FirstName = "Raphael",
                    Surname = "Gomes",
                    Age = 44,
                    CreationDate = DateTime.Now
                }
            };

        public static User GetTestUser(Guid _id) {
            return new User() {
                Id = _id,
                FirstName = "Some name",
                Surname = "some surname",
                Age = 78,
                CreationDate = DateTime.Now
            };
        }

        public static User GetTestUserWithoutFirstName() {
            return new User() {
                Surname = "some surname",
                Age = 78
            };
        }

        public static User GetTestUserWithAgeZero() {
            return new User() {
                FirstName = "Some name",
                Surname = "some surname",
                Age = 0
            };
        }
    }
    
}