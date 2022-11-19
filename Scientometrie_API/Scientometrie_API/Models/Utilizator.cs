using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class Utilizator
{
    public int ID { get; set; }
    public string NumeUtilizator { get; set; } = null!;
    public string Parola { get; set; } = null!;
    public int Drepturi { get; set; }
    public string Email { get; set; } = null!;
    public string? Cod { get; set; }

    public virtual ICollection<Articol> Articol { get; } = new List<Articol>();

}
