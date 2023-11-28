using eCommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebApi.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasIndex(p => p.Name).IsUnique();
    }
}
