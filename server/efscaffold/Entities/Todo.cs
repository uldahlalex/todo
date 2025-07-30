using System;
using System.Collections.Generic;

namespace efscaffold.Entities;

public partial class Todo
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Priority { get; set; }

    public bool Isdone { get; set; }
}
