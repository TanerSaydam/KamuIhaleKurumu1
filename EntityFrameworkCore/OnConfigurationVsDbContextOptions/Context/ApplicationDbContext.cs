using Microsoft.EntityFrameworkCore;
using OnConfigurationVsDbContextOptions.Entities;

namespace OnConfigurationVsDbContextOptions.Context;

public sealed class ApplicationDbContext : DbContext
{
    #region Alternatif Yöntem
    //private readonly IConfiguration _configuration;

    //public ApplicationDbContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();
    //    string connectinString = configuration.GetSection("SqlServer").Value;
    //    optionsBuilder.UseSqlServer(connectinString);
    //}
    #endregion

    public ApplicationDbContext(DbContextOptions options) : base(options) {}
    public DbSet<Product> Products { get; set; }
}
