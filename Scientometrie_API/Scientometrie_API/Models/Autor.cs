using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class Autor
{
    public int ID { get; set; }
    public int Tip { get; set; }
    public bool Aprobat { get; set; }
    public string? UEFID { get; set; }
    public string Contact { get; set; } = null!;
    public string Nume { get; set; } = null!;
    public string Prenume { get; set; } = null!;

    public virtual ICollection<AfiliereAutor> AfiliereAutor { get; } = new List<AfiliereAutor>();
    public virtual ICollection<AutorArticol> AutorArticol { get; } = new List<AutorArticol>();
}
