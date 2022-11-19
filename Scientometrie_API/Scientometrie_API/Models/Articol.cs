using System;
using System.Collections.Generic;

namespace Scientometrie_API.Models;

public partial class Articol
{
    public int ID { get; set; }
    public string Titlu { get; set; } = null!;
    public int Vizitatori { get; set; }
    public DateTime? Data { get; set; }
    public string? Pagina { get; set; }
    public string? Volum { get; set; }
    public string? Numar { get; set; }
    public string? Doi { get; set; }
    public string? Wos { get; set; }

    public int IDPublicatie { get; set; }
    public int IDUtilizator { get; set; }

    public virtual ICollection<AutorArticol> AutorArticol { get; } = new List<AutorArticol>();
    public virtual ICollection<Citare> Citare { get; } = new List<Citare>();
    public virtual Publicatie IDPublicatieNavigation { get; set; } = null!;
    public virtual Utilizator IDUtilizatorNavigation { get; set; } = null!;
}
