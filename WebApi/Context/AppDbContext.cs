using KIKWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KIKWebApi.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
    }

    public DbSet<Personel> Personels { get; set; }
    public DbSet<User> Users { get; set; }
}
