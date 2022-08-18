using Clients.API.Models;

namespace Clients.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new() {
                new User {
                    id = Guid.NewGuid(),
                    firstName = "João",
                    surname = "Silva",
                    age = 28,
                    creationDate = DateTime.Now
                },
                new User {
                    id = Guid.NewGuid(),
                    firstName = "Pedro",
                    surname = "Oliveira",
                    age = 56,
                    creationDate = DateTime.Now
                },
                new User {
                    id = Guid.NewGuid(),
                    firstName = "Raphael",
                    surname = "Gomes",
                    age = 44,
                    creationDate = DateTime.Now
                }
            };

        public static User GetTestUser(Guid _id) {
            return new User() {
                id = _id,
                firstName = "Some name",
                surname = "some surname",
                age = 78,
                creationDate = DateTime.Now
            };
        }
    }
}