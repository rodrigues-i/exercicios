using CrudClientes.Models;

namespace CrudClientes.Repository;

public interface IUserRepository
{
    Task<List<User>> GetUsers();
    Task<User?> GetUserById(Guid id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    Task<bool> SaveChangesAsync();
}