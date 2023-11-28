using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Post
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Created { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public virtual User User { get; set; } = null!;
}
