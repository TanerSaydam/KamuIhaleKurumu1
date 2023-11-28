using Microsoft.EntityFrameworkCore;

namespace BenchMark;

internal sealed class AppDbContext : DbContext
{
    private static readonly Func<AppDbContext, int, Task<AppUser?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, int id) =>
         context.Set<AppUser>().AsNoTracking().FirstOrDefault(x => x.Id == id));
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=TUGAY\\SQLEXPRESS;Initial Catalog=BenchMarkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<AppUser> Users { get; set; }

    public async Task<AppUser?> GetUserByIdCompiled(int id)
    {
        return await GetById(this, id);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasData(
            new AppUser() { Id = 1, Name = "Taner Saydam" });
    }
}

public sealed class AppUser
{
    public int Id { get; set; }
    public string Name { get; set; }
}
