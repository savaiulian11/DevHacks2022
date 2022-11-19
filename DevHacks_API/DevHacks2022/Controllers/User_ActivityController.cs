using DevHacks2022.Models;
using DevHacks2022.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_ActivityController : ControllerBase
    {
        private DevHacks2022Context _context;
        public User_ActivityController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<UserActivity>> GetAll()
        {
            try
            {
                return _context.UserActivities.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] UserActivity userActivity)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, userActivity, BasicQuery.User_Activity);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into User_Activity.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] UserActivity userActivity)
        {

            try
            {
                BasicQuery.Update(_context, userActivity, BasicQuery.User_Activity);
                return StatusCode(200, "Update into User_Activity succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into User_Activity.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.User_Activity);
                return StatusCode(200, "Delete into User_Activity succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into User_Activity.\n" + ex.Message);
            }
        }
    }
}
