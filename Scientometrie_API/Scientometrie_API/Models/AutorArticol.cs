using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class AutorArticol
{
    public int ID { get; set; }

    public int IDAutor { get; set; }
    public int IDArticol { get; set; }

    public virtual Articol IDArticolNavigation { get; set; } = null!;
    public virtual Autor IDAutorNavigation { get; set; } = null!;
}
