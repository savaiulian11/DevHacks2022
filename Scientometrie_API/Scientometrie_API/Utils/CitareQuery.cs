using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class CitareQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.Citare.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, Citare citare)
        {
            if (ArticolQuery.IDExistent(citare.IDArticol, _context) == -1)
                throw (new Exception("Insert into Citare failed! IDArticol not found"));
            _context.Citare.Add(citare);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", citare.ID.ToString());
            response.Add("Message", "Insert into Citare succesfull");

            return response;
        }

        public static void Update(ScientometrieDbContext _context, Citare citare)
        {
            if (ArticolQuery.IDExistent(citare.IDArticol, _context) == -1)
                throw (new Exception("Update into Citare failed! IDArticol not found"));
            _context.Entry(citare).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            Citare Citare = _context.Citare.Find(ID);
            if (Citare == null)
                throw new Exception("ID Citare not found!");
            _context.Citare.Remove(Citare);
            _context.SaveChanges();
        }
    }
}
