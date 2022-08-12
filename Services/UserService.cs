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

    public static void Update(User user) {
        var index = Users.FindIndex(u => u.id == user.id);
        if(index == -1)
            return;
        Users[index] = user;
    }

    public static void Delete(int id)
    {
        var user = GetById(id);
        if(user is null)
            return;
        Users.Remove(user);

    }
}