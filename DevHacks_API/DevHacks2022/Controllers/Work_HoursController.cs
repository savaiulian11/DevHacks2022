using DevHacks2022.Models;
using DevHacks2022.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Work_HoursController : ControllerBase
    {
        private DevHacks2022Context _context;
        public Work_HoursController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<WorkHour>> GetAll()
        {
            try
            {
                return _context.WorkHours.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] WorkHour workHour)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, workHour, BasicQuery.Work_Hours);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Work_Hours.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] WorkHour Work_hours)
        {

            try
            {
                BasicQuery.Update(_context, Work_hours, BasicQuery.Work_Hours);
                return StatusCode(200, "Update into Work_Hours succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Company_User.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.Work_Hours);
                return StatusCode(200, "Delete into Work_Hours succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Work_Hours.\n" + ex.Message);
            }
        }
    }

}

