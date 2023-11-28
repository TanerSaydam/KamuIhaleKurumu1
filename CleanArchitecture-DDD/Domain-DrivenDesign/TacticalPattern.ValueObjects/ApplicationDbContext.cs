using Microsoft.EntityFrameworkCore;

namespace TacticalPattern.ValueObjects;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Customer>()
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new CusomerId(value));

        modelBuilder.Entity<Customer>()
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new Name(value));

        modelBuilder.Entity<Customer>()
            .Property(p => p.Lastname)
            .HasConversion(lastname => lastname.Value, value => new Lastname(value));

        modelBuilder.Entity<Customer>()
            .OwnsOne(p => p.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.City).HasMaxLength(200);
                addressBuilder.Property(a => a.Country).HasMaxLength(200);
                addressBuilder.Property(a => a.FullAddress).HasMaxLength(200);
            });

        modelBuilder.Entity<Customer>()
            .OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(price => price.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });
    }
}