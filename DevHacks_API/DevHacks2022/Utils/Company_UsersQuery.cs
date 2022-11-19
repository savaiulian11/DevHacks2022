using DevHacks2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class Company_UsersQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.CompanyUsers.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context, CompanyUser companyuser)
        {
            _context.CompanyUsers.Add(companyuser);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", companyuser.Id.ToString());
            response.Add("Message", "Insert into Rewards_User succesfull");
            return response;
        }

        public static void Update(DevHacks2022Context _context, CompanyUser companyuser)
        {
            _context.Entry(companyuser).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
           CompanyUser companyuser = _context.CompanyUsers.Find(ID);
            if (companyuser == null)
                throw new Exception("ID Rewards_Users not found!");
            _context.CompanyUsers.Remove(companyuser);
            _context.SaveChanges();
        }
    }
}
