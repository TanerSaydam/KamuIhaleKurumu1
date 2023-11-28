using System;
using System.Collections.Generic;

namespace DbFirst.Models2;

public partial class UserRole
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
