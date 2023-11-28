using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BenchMark;

[Config(typeof(Config))]
public class BenchMarkService
{
    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Trend);
        }
    }
    [Benchmark(Baseline = true)]
    public async Task<AppUser> GetById()
    {
        AppDbContext context = new();
        return await context.Set<AppUser>().AsNoTracking().Where(p => p.Id == 1).FirstOrDefaultAsync();
    }

    [Benchmark]
    public async Task<AppUser> GetByIdCompiled()
    {
        AppDbContext context = new();
        return await context.GetUserByIdCompiled(1);
    }

    [Benchmark]
    public void GetUserBySqlQuery()
    {
        SqlConnection connection = new("Data Source=TUGAY\\SQLEXPRESS;Initial Catalog=BenchMarkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        connection.Open();
        SqlCommand cmd = new("Select Top 1 * From Users where Id=1", connection);        
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        connection.Close();
    }
    [Benchmark]
    public void GetUserByEFQuery()
    {
        AppDbContext context = new();
        var user =  context.Users.FromSqlRaw("Select Top 1 * From Users where Id=1");
    }

    [Benchmark]
    public void GetUserByEFProcedure()
    {
        AppDbContext context = new();
        var user = context.Database.ExecuteSqlRaw("exec GetUserById");
    }

    [Benchmark]
    public void GetUserBySQLProcedure()
    {
        SqlConnection connection = new("Data Source=TUGAY\\SQLEXPRESS;Initial Catalog=BenchMarkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        connection.Open();
        SqlCommand cmd = new("exec GetUserById", connection);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        connection.Close();
    }
}
