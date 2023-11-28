using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class PostLike
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public virtual Post Post { get; set; } = null!;
}
