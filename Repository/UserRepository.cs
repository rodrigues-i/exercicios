using CrudClientes.Models;
using CrudClientes.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudClientes.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
        
    }
    public void AddUser(User user)
    {
        _context.Add(user);
    }

    public void DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}