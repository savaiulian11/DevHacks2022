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
    public class Company_UsersController : ControllerBase
    {
        private DevHacks2022Context _context;
        public Company_UsersController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<CompanyUser>> GetAll()
        {
            try
            {
                return _context.CompanyUsers.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] CompanyUser Company_user)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Company_user, BasicQuery.Company_Users);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Company_Users.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] CompanyUser Company_user)
        {

            try
            {
                BasicQuery.Update(_context,Company_user, BasicQuery.Company_Users);
                return StatusCode(200, "Update into Company_User succesfull");
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
                BasicQuery.Delete(_context, ID, BasicQuery.Company_Users);
                return StatusCode(200, "Delete into Company_User succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Company_User.\n" + ex.Message);
            }
        }
    }
}

