#nullable disable
using Microsoft.EntityFrameworkCore;
namespace usersApi.Models;

public class UsersAPIContext : DbContext
{
  public UsersAPIContext(DbContextOptions<UsersAPIContext> options) : base(options) { }

  public DbSet<usersApi.Models.User> User { get; set; }

}