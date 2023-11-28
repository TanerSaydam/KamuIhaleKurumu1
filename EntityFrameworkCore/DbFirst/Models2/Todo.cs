using System;
using System.Collections.Generic;

namespace DbFirst.Models2;

public partial class Todo
{
    public int Id { get; set; }

    public string? Work { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedDate { get; set; }
}
