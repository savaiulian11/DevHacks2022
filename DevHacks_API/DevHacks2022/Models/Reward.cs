using System;
using System.Collections.Generic;

namespace DevHacks2022.Models;

public partial class Reward
{
    public int Id { get; set; }

    public int Provider { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Milestone { get; set; }

}
