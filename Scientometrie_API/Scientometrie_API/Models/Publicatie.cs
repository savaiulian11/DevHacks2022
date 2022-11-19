using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class Publicatie
{
    public int ID { get; set; }
    public string? Nume { get; set; }
    public int IDTipIndexare { get; set; }
    public int IDTipPublicatie { get; set; }

    public virtual ICollection<Articol> Articol { get; } = new List<Articol>();
    public virtual TipIndexare IDTipIndexareNavigation { get; set; } = null!;
    public virtual TipPublicatie IDTipPublicatieNavigation { get; set; } = null!;
}
