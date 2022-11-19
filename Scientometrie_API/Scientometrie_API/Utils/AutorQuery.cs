using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class AutorQuery
    {
        public static List<Autor> GetUnaccredited(ScientometrieDbContext _context)
        {
            var autori = _context.Autor.Where(m => m.Aprobat == false).ToList();
            return autori;
        }
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.Autor.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null;
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, Autor autor)
        {
            _context.Autor.Add(autor);
            _context.SaveChanges();

            var response = new Dictionary<string, string>();
            response.Add("ID", autor.ID.ToString());
            response.Add("Message", "Insert into Autor succesfull");
            return response;
        }

        public static void Update(ScientometrieDbContext _context, Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            Autor Autor = _context.Autor.Find(ID);
            if (Autor == null)
                throw new Exception("ID Autor not found!");
            _context.Autor.Remove(Autor);
            _context.SaveChanges();
        }
    }
}
