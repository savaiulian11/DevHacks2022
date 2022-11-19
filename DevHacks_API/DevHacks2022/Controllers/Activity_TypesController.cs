using DevHacks2022.Models;
using DevHacks2022.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Activity_TypesController : ControllerBase
    {
        private DevHacks2022Context _context;
        public Activity_TypesController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<ActivityType>> GetAll()
        {
            try
            {
                return _context.ActivityTypes.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] ActivityType activitytype)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, activitytype, BasicQuery.Activity_Types);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Activity_Types .\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] ActivityType activitytype)
        {

            try
            {
                BasicQuery.Update(_context, activitytype, BasicQuery.Activity_Types);
                return StatusCode(200, "Update into Activity_Types succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Activity_Types.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.Activity_Types);
                return StatusCode(200, "Delete into Activity_Types succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Activity_Types.\n" + ex.Message);
            }
        }
    }
}

