using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class AutorArticolQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.AutorArticol.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null;
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, AutorArticol autorArticol)
        {
            if (ArticolQuery.IDExistent(autorArticol.IDArticol, _context) == -1)
                throw (new Exception("Insert into AutorArticol failed! IDArticol not found"));
            if (AutorQuery.IDExistent(autorArticol.IDAutor, _context) == -1)
                throw (new Exception("Insert into AutorArticol failed! IDAutor not found"));
            _context.AutorArticol.Add(autorArticol);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", autorArticol.ID.ToString());
            response.Add("Message", "Insert into AfiliereAutor succesfull");

            return response;
        }

        public static void Update(ScientometrieDbContext _context, AutorArticol autorArticol)
        {
            if (ArticolQuery.IDExistent(autorArticol.IDArticol, _context) == -1)
                throw (new Exception("Update into AutorArticol failed! IDArticol not found"));
            if (AutorQuery.IDExistent(autorArticol.IDAutor, _context) == -1)
                throw (new Exception("Update into AutorArticol failed! IDAutor not found"));
            _context.Entry(autorArticol).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            AutorArticol AutorArticol = _context.AutorArticol.Find(ID);
            if (AutorArticol == null)
                throw new Exception("ID AutorArticol not found!");
            _context.AutorArticol.Remove(AutorArticol);
            _context.SaveChanges();
        }
    }
}
