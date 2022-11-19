using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;

namespace Scientometrie_API.Utils
{
    public class PublicatieQuery
    {
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.Publicatie.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null; 
            return _ID;
        }

        public static dynamic Insert(ScientometrieDbContext _context, Publicatie publicatie)
        {
            if (TipPublicatieQuery.IDExistent(publicatie.IDTipPublicatie, _context) == -1)
                throw (new Exception("Insert into Publicatie failed! IDTipPublicatie not found"));
            if (TipIndexareQuery.IDExistent(publicatie.IDTipIndexare, _context) == -1)
                throw (new Exception("Insert into Publicatie failed! IDTipIndexare not found"));
            _context.Publicatie.Add(publicatie);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", publicatie.ID.ToString());
            response.Add("Message", "Insert into Publicatie succesfull");
            return response;
        }

        public static void Update(ScientometrieDbContext _context, Publicatie publicatie)
        {
            if (TipPublicatieQuery.IDExistent(publicatie.IDTipPublicatie, _context) == -1)
                throw (new Exception("Update into Publicatie failed! IDTipPublicatie not found"));
            if (TipIndexareQuery.IDExistent(publicatie.IDTipIndexare, _context) == -1)
                throw (new Exception("Update into Publicatie failed! IDTipIndexare not found"));
            _context.Entry(publicatie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            Publicatie Publicatie = _context.Publicatie.Find(ID);
            if (Publicatie == null)
                throw new Exception("ID Publicatie not found!"); ;
            _context.Publicatie.Remove(Publicatie);
            _context.SaveChanges();
        }
    }
}
