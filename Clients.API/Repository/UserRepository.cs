using Clients.API.Models;
using Clients.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Clients.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;

    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public void UpdateUser(User user)
    {
        _context.Update(user);
    }

    public void AddUser(User user)
    {
        _context.Add(user);
    }

    public void DeleteUser(User user)
    {
        _context.Remove(user);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}