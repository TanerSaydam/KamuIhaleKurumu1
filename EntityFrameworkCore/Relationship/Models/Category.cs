using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Relationship.Models;

public sealed class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set;}
}

public sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    //[ForeignKey("Category")]
    //public int CategoryId { get; set; }
    //public Category Category { get; set; }
    public ICollection<Category> Categories { get; set;}
}

public sealed class CategoryProduct
{
    public int Id { get; set; }

    //[ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    //[ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}

public sealed class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    //public SharedUserInformation? SharedUserInformation { get; set; }

}

public sealed class Customer
{
    public int Id { get; set; }
    public SharedUserInformation SharedUserInformation { get; set; }
}

[Owned]
public class SharedUserInformation
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string FullAddress { get; set; }
}