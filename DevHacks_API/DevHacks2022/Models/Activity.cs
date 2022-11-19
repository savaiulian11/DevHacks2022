using System;
using System.Collections.Generic;

namespace DevHacks2022.Models;

public partial class Activity
{
    public int Id { get; set; }

    public int IdType { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Link { get; set; }

}
