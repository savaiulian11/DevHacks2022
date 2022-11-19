using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;


namespace Scientometrie_API.Utils
{
    public class BasicQuery
    {
        public const int AFILIERE = 1;
        public const int AFILIEREAUTOR = 2;
        public const int AUTOR = 3;
        public const int ARTICOL = 4;
        public const int AUTORARTICOL = 5;
        public const int CITARE = 6;
        public const int PUBLICATIE = 7;
        public const int TIPINDEXARE = 8;
        public const int TIPPUBLICATIE = 9;
        public const int UTILIZATOR = 10;

        public static dynamic Insert<T>(ScientometrieDbContext _context, T obiect, int tabel)
        {
            dynamic result = new JObject();
            switch (tabel)
            {
                case AFILIERE:
                    result = AfiliereQuery.Insert(_context, (Afiliere)Convert.ChangeType(obiect, typeof(Afiliere)));
                    break;
                case AFILIEREAUTOR:
                    result = AfiliereAutorQuery.Insert(_context, (AfiliereAutor)Convert.ChangeType(obiect, typeof(AfiliereAutor)));
                    break;
                case AUTOR:
                    result = AutorQuery.Insert(_context, (Autor)Convert.ChangeType(obiect, typeof(Autor)));
                    break;
                case ARTICOL:
                    result = ArticolQuery.Insert(_context, (Articol)Convert.ChangeType(obiect, typeof(Articol)));
                    break;
                case AUTORARTICOL:
                    result = AutorArticolQuery.Insert(_context, (AutorArticol)Convert.ChangeType(obiect, typeof(AutorArticol)));
                    break;
                case CITARE:
                    result = CitareQuery.Insert(_context, (Citare)Convert.ChangeType(obiect, typeof(Citare)));
                    break;
                case PUBLICATIE:
                    result = PublicatieQuery.Insert(_context, (Publicatie)Convert.ChangeType(obiect, typeof(Publicatie)));
                    break;
                case TIPINDEXARE:
                    result = TipIndexareQuery.Insert(_context, (TipIndexare)Convert.ChangeType(obiect, typeof(TipIndexare)));
                    break;
                case TIPPUBLICATIE:
                    result = TipPublicatieQuery.Insert(_context, (TipPublicatie)Convert.ChangeType(obiect, typeof(TipPublicatie)));
                    break;
                case UTILIZATOR:
                    result = UtilizatorQuery.Insert(_context, (Utilizator)Convert.ChangeType(obiect, typeof(Utilizator)));
                    break;
            }
            return result;
        }
        public static void Update<T>(ScientometrieDbContext _context, T obiect, int tabel)
        {
            switch (tabel)
            {
                case AFILIERE:
                    AfiliereQuery.Update(_context, (Afiliere)Convert.ChangeType(obiect, typeof(Afiliere)));
                    break;
                case AFILIEREAUTOR:
                    AfiliereAutorQuery.Update(_context, (AfiliereAutor)Convert.ChangeType(obiect, typeof(AfiliereAutor)));
                    break;
                case AUTOR:
                    AutorQuery.Update(_context, (Autor)Convert.ChangeType(obiect, typeof(Autor)));
                    break;
                case ARTICOL:
                    ArticolQuery.Update(_context, (Articol)Convert.ChangeType(obiect, typeof(Articol)));
                    break;
                case AUTORARTICOL:
                    AutorArticolQuery.Update(_context, (AutorArticol)Convert.ChangeType(obiect, typeof(AutorArticol)));
                    break;
                case CITARE:
                    CitareQuery.Update(_context, (Citare)Convert.ChangeType(obiect, typeof(Citare)));
                    break;
                case PUBLICATIE:
                    PublicatieQuery.Update(_context, (Publicatie)Convert.ChangeType(obiect, typeof(Publicatie)));
                    break;
                case TIPINDEXARE:
                    TipIndexareQuery.Update(_context, (TipIndexare)Convert.ChangeType(obiect, typeof(TipIndexare)));
                    break;
                case TIPPUBLICATIE:
                    TipPublicatieQuery.Update(_context, (TipPublicatie)Convert.ChangeType(obiect, typeof(TipPublicatie)));
                    break;
                case UTILIZATOR:
                    UtilizatorQuery.Update(_context, (Utilizator)Convert.ChangeType(obiect, typeof(Utilizator)));
                    break;
            }
        }
        public static void Delete(ScientometrieDbContext _context, int ID, int tabel)
        {
            switch (tabel)
            {
                case AFILIERE:
                    AfiliereQuery.Delete(_context, ID);
                    break;
                case AFILIEREAUTOR:
                    AfiliereAutorQuery.Delete(_context, ID);
                    break;
                case AUTOR:
                    AutorQuery.Delete(_context, ID);
                    break;
                case ARTICOL:
                    ArticolQuery.Delete(_context, ID);
                    break;
                case AUTORARTICOL:
                    AutorArticolQuery.Delete(_context, ID);
                    break;
                case CITARE:
                    CitareQuery.Delete(_context, ID);
                    break;
                case PUBLICATIE:
                    PublicatieQuery.Delete(_context, ID);
                    break;
                case TIPINDEXARE:
                    TipIndexareQuery.Delete(_context, ID);
                    break;
                case TIPPUBLICATIE:
                    TipPublicatieQuery.Delete(_context, ID);
                    break;
                case UTILIZATOR:
                    UtilizatorQuery.Delete(_context, ID);
                    break;
            }
        }
    }
}
