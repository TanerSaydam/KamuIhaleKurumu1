using Microsoft.EntityFrameworkCore;
using Relationship.Models;

namespace Relationship.Context;

public sealed class AppDbContext : DbContext
{
    private static readonly Func<AppDbContext, int, Task<User?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, int id) =>
            context.Set<User>().AsNoTracking().FirstOrDefault(p => p.Id == id));

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public async Task<User?> GetUserByIdCompiled(int id)
    {
        return await GetById(this, id);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryProduct> CategoryProducts { get; set; }
    public DbSet<User> Users { get; set; }
    //public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Product>()
        //    .HasOne(p => p.Category)
        //    .WithMany(p => p.Products)
        //    .HasForeignKey("CategoryId");

        //modelBuilder.Entity<Category>()
        //    .HasMany(p=> p.Products)
        //    .WithOne(p=> p.Category)
        //    .HasForeignKey("CategoryId")
        //    .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithMany(p => p.Products)
            .UsingEntity<CategoryProduct>();

        modelBuilder.Entity<Category>()
            .HasMany(p => p.Products)
            .WithMany(p => p.Categories)
            .UsingEntity<CategoryProduct>();

        modelBuilder.Entity<User>().HasData(
            new User() { Id=1, Email = "tanersaydam@gmail.com" });

        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(6,2)");

        //modelBuilder.Entity<User>().OwnsOne(p => p.SharedUserInformation);
        //modelBuilder.Entity<Customer>()
        //    .OwnsOne(p => p.SharedUserInformation)
        //    .Property(p => p.Name)
        //    .HasColumnName("Name");
    }
}
