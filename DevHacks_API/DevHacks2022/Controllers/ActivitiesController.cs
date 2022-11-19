using DevHacks2022.Models;
using DevHacks2022.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private DevHacks2022Context _context;
        public ActivitiesController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Activity>> GetAll()
        {
            try
            {
                return _context.Activities.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Activity activity)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, activity, BasicQuery.Activities);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Activity.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Activity activity)
        {

            try
            {
                BasicQuery.Update(_context, activity, BasicQuery.Activities);
                return StatusCode(200, "Update into Activity succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Activity.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.Activities);
                return StatusCode(200, "Delete into Activity succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Activity.\n" + ex.Message);
            }
        }
    }
}

