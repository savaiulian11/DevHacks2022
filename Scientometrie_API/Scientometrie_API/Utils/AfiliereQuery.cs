using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class AfiliereQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.Afiliere.Find(ID);
            if (temp == null)
                return -1;
            return temp.ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, Afiliere afiliere)
        {
            _context.Afiliere.Add(afiliere);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", afiliere.ID.ToString());
            response.Add("Message", "Insert into Afiliere succesfull");
            return response;
        }

        public static void Update(ScientometrieDbContext _context, Afiliere afiliere)
        {
            _context.Entry(afiliere).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            Afiliere Afiliere = _context.Afiliere.Find(ID);
            if (Afiliere == null)
                throw new Exception("ID Afiliere not found!");
            _context.Afiliere.Remove(Afiliere);
            _context.SaveChanges();
        }
    }
}
