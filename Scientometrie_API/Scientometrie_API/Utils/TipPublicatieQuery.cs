using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class TipPublicatieQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.TipPublicatie.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null;
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, TipPublicatie tipPublicatie)
        {
            _context.TipPublicatie.Add(tipPublicatie);
            _context.SaveChanges();

            var response = new Dictionary<string, string>();
            response.Add("ID", tipPublicatie.ID.ToString());
            response.Add("Message", "Insert into TipPublicatie succesfull");
            return response;
        }

        public static void Update(ScientometrieDbContext _context, TipPublicatie tipPublicatie)
        {
            _context.Entry(tipPublicatie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            TipPublicatie TipPublicatie = _context.TipPublicatie.Find(ID);
            if (TipPublicatie == null)
                throw new Exception("ID TipPublicatie not found!");
            _context.TipPublicatie.Remove(TipPublicatie);
            _context.SaveChanges();
        }
    }
}
