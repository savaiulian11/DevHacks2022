using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class TipIndexareQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.TipIndexare.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null;
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, TipIndexare tipIndexare)
        {
            _context.TipIndexare.Add(tipIndexare);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", tipIndexare.ID.ToString());
            response.Add("Message", "Insert into TipIndexare succesfull");
            return response;
        }

        public static void Update(ScientometrieDbContext _context, TipIndexare tipIndexare)
        {
            _context.Entry(tipIndexare).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            TipIndexare TipIndexare = _context.TipIndexare.Find(ID);
            if (TipIndexare == null)
                throw new Exception("ID TipIndexare not found!");
            _context.TipIndexare.Remove(TipIndexare);
            _context.SaveChanges();
        }
    }
}
