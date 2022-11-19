using DevHacks2022.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DevHacks2022.Models;


namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rewards_UserController : ControllerBase
    {
        private DevHacks2022Context _context;
        public Rewards_UserController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<RewardsUser>> GetAll()
        {
            try
            {
                return _context.RewardsUsers.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] RewardsUser Reward_user)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Reward_user, BasicQuery.Rewards_User);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Rewards_User.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] RewardsUser Reward_user)
        {

            try
            {
                BasicQuery.Update(_context, Reward_user, BasicQuery.Rewards_User);
                return StatusCode(200, "Update into Rewards_User succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Rewards_User.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.Rewards_User);
                return StatusCode(200, "Delete into Rewards_User succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Rewards_User.\n" + ex.Message);
            }
        }
    }

}

