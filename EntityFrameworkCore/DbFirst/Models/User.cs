using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
