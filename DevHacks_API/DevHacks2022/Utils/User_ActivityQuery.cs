using DevHacks2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_ActivityQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.UserActivities.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context,UserActivity useractivity)
        {
            _context.UserActivities.Add(useractivity);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", useractivity.Id.ToString());
            response.Add("Message", "Insert into User_Activity succesfull");
            return useractivity;
        }

        public static void Update(DevHacks2022Context _context, UserActivity useractivity)
        {
            _context.Entry(useractivity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
            UserActivity useractivity = _context.UserActivities.Find(ID);
            if (useractivity == null)
                throw new Exception("ID User_Activity not found!");
            _context.UserActivities.Remove(useractivity);
            _context.SaveChanges();
        }
    }
}
