using DevHacks2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.Companies.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context, Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", company.Id.ToString());
            response.Add("Message", "Insert into Company succesfull");
            return response;
        }

        public static void Update(DevHacks2022Context _context, Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
            Company company = _context.Companies.Find(ID);
            if (company == null)
                throw new Exception("ID Company not found!");
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }
    }
}
