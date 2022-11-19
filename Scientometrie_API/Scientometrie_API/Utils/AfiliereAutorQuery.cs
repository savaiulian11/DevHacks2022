using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class AfiliereAutorQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.AfiliereAutor.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null;
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, AfiliereAutor afiliereAutor)
        {
            if (AfiliereQuery.IDExistent(afiliereAutor.IDAfiliere, _context) == -1)
                throw (new Exception("Insert into AfiliereAutor failed! IDAfiliere not found"));
            if (AutorQuery.IDExistent(afiliereAutor.IDAutor, _context) == -1)
                throw (new Exception("Insert into AfiliereAutor failed! IDAutor not found"));
            _context.AfiliereAutor.Add(afiliereAutor);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", afiliereAutor.ID.ToString());
            response.Add("Message", "Insert into AfiliereAutor succesfull");
            return response;
        }

        public static void Update(ScientometrieDbContext _context, AfiliereAutor afiliereAutor)
        {
            if (AfiliereQuery.IDExistent(afiliereAutor.IDAfiliere, _context) == -1)
                throw (new Exception("Update into AfiliereAutor failed! IDAfiliere not found"));
            if (AutorQuery.IDExistent(afiliereAutor.IDAutor, _context) == -1)
                throw (new Exception("Update into AfiliereAutor failed! IDAutor not found"));
            _context.Entry(afiliereAutor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            AfiliereAutor AfiliereAutor = _context.AfiliereAutor.Find(ID);
            if (AfiliereAutor == null)
                throw new Exception("ID AfiliereAutor not found!");
            _context.AfiliereAutor.Remove(AfiliereAutor);
            _context.SaveChanges();
        }
    }
}
