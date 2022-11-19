using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class Citare
{
    public int ID { get; set; }
    public string Doi { get; set; } = null!;

    public int IDArticol { get; set; }
    
    public virtual Articol IDArticolNavigation { get; set; } = null!;

}
