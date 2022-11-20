using DevHacks2022.Models;
using DevHacks2022.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private DevHacks2022Context _context;
        public RewardsController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Reward>> GetAll()
        {
            try
            {
                return _context.Rewards.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Reward reward)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, reward, BasicQuery.Rewards);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Rewards.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Reward reward)
        {

            try
            {
                BasicQuery.Update(_context, reward, BasicQuery.Rewards);
                return StatusCode(200, "Update into Rewards succesfull");
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
                BasicQuery.Delete(_context, ID, BasicQuery.Rewards);
                return StatusCode(200, "Delete into Rewards succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Rewards.\n" + ex.Message);
            }
        }
    }
}

