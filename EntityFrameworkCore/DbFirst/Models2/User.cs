using System;
using System.Collections.Generic;

namespace DbFirst.Models2;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Provider { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpires { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
