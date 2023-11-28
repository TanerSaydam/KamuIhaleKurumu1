using _01.MyFirstApi.Context;
using _01.MyFirstApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(opt => opt.AddDefaultPolicy(cfr =>
{
    cfr
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(cfr=> true)
    .AllowCredentials();
}));

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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    AppDbContext appContext = new();
    //appContext.Database.Migrate();
    var isProductHave = appContext.Set<Product>().Any();
    if (!isProductHave)
    {
        List<Product> products = new List<Product>();
    for (int i = 0; i < 4000; i++)
    {
        Product product = new()
        {
            Name = "Product " + i,
            Price = i * 5
        };
        products.Add(product);
    }

    appContext.Set<Product>().AddRange(products);
    appContext.SaveChanges();
    }    
}


app.MapControllers();



app.Run();
