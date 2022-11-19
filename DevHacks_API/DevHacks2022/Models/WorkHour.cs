using System;
using System.Collections.Generic;

namespace DevHacks2022.Models;

public partial class WorkHour
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateTime ActiveTime { get; set; }

}
