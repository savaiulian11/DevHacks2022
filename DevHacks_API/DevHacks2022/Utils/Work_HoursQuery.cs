using DevHacks2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class Work_HoursQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.WorkHours.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context,WorkHour workhour)
        {
            _context.WorkHours.Add(workhour);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", workhour.Id.ToString());
            response.Add("Message", "Insert into Work_Hours succesfull");
            return response;
        }

        public static void Update(DevHacks2022Context _context, WorkHour workhour)
        {
            _context.Entry(workhour).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
            WorkHour workhour = _context.WorkHours.Find(ID);
            if (workhour == null)
                throw new Exception("ID Work_Hours not found!");
            _context.WorkHours.Remove(workhour);
            _context.SaveChanges();
        }
    }
}
