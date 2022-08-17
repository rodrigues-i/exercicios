using Microsoft.EntityFrameworkCore;
using Clients.API.Models;

namespace Clients.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }
}