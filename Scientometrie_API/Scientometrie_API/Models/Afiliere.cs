using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class Afiliere
{
    public int ID { get; set; }
    public string NumeInstitutie { get; set; } = null!;

    public virtual ICollection<AfiliereAutor> AfiliereAutor { get; } = new List<AfiliereAutor>();
}
