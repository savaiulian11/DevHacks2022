namespace Scientometrie_API.Models;

public partial class AfiliereAutor
{
    public int ID { get; set; }

    public int IDAfiliere { get; set; }
    public int IDAutor { get; set; }

    public virtual Afiliere IDAfiliereNavigation { get; set; } = null!;
    public virtual Autor IDAutorNavigation { get; set; } = null!;
}
