using Microsoft.EntityFrameworkCore;

namespace JwtWebapiTutorial.Models;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; } = null!;
}