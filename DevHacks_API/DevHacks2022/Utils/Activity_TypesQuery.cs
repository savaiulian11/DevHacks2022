using DevHacks2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class Activity_TypesQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.ActivityTypes.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context, ActivityType activitytype)
        {
            _context.ActivityTypes.Add(activitytype);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", activitytype.Id.ToString());
            response.Add("Message", "Insert into Activity_Types succesfull");
            return response;
        }

        public static void Update(DevHacks2022Context _context, ActivityType activitytype)
        {
            _context.Entry(activitytype).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
            ActivityType activitytype = _context.ActivityTypes.Find(ID);
            if (activitytype == null)
                throw new Exception("ID Rewards_Users not found!");
            _context.ActivityTypes.Remove(activitytype);
            _context.SaveChanges();
        }
    }
}
