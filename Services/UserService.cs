using CrudClientes.Models;

namespace CrudClientes.Services;

public static class UserService
{
    static List<User> Users {get;}
    static int nextId = 3;

    static UserService()
    {
        Users = new List<User>
        {
            new User { id = 1, firstName = "João Henrique", surname = "Silva", age = 28},
            new User {id = 2, firstName = "Maria", surname = "Cardoso", age = 33}
        };

    }

    public static List<User> GetAll() => Users;

    public static User? GetById(int id) => Users.FirstOrDefault(user => user.id == id);

    public static void Add(User user)
    {
        user.id = nextId++;
        Users.Add(user);
    }
}