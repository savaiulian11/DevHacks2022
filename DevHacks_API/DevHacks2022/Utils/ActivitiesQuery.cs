using DevHacks2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.Activities.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context, Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", activity.Id.ToString());
            response.Add("Message", "Insert into Activities succesfull");
            return response;
        }

        public static void Update(DevHacks2022Context _context, Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
            Activity activity = _context.Activities.Find(ID);
            if (activity == null)
                throw new Exception("ID Activities not found!");
            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }
    }
}
