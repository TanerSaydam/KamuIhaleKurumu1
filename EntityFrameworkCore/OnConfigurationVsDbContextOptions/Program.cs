using Microsoft.EntityFrameworkCore;
using OnConfigurationVsDbContextOptions.Context;
using OnConfigurationVsDbContextOptions.IoC;

var builder = WebApplication.CreateBuilder(args);

const string SqlServer = nameof(SqlServer);
string connectionString = builder.Configuration.GetSection(SqlServer).Value;

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(connectionString));

builder.Services.CreateProvider();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
