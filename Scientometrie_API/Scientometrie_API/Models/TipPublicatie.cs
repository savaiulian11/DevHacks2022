using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class TipPublicatie
{
    public int ID { get; set; }
    public string Tip { get; set; } = null!;

    public virtual ICollection<Publicatie> Publicatie { get; } = new List<Publicatie>();
}
