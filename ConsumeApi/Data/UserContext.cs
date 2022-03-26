using ConsumeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumeApi.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; } = null!;
}