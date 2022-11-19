using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class ArticolQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.Articol.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null;
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, Articol articol)
        {
            if (PublicatieQuery.IDExistent(articol.IDPublicatie, _context) == -1)
                throw (new Exception("Insert into Autor failed! IDPublicatie not found"));
            if (UtilizatorQuery.IDExistent(articol.IDUtilizator, _context) == -1)
                throw (new Exception("Insert into Autor failed! IDUtilizator not found"));
            _context.Articol.Add(articol);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", articol.ID.ToString());
            response.Add("Message", "Insert into Articol succesfull");
            return response;
        }

        public static void Update(ScientometrieDbContext _context, Articol articol)
        {
            if (PublicatieQuery.IDExistent(articol.IDPublicatie, _context) == -1)
                throw (new Exception("Insert into Autor failed! IDPublicatie not found"));
            if (UtilizatorQuery.IDExistent(articol.IDUtilizator, _context) == -1)
                throw (new Exception("Insert into Autor failed! IDUtilizator not found"));
            _context.Entry(articol).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            Articol Articol = _context.Articol.Find(ID);
            if (Articol == null)
                throw new Exception("ID Articol not found!");
            _context.Articol.Remove(Articol);
            _context.SaveChanges();
        }
    }
}
