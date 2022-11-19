using DevHacks2022.Models;
using DevHacks2022.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private DevHacks2022Context _context;
        public CompanyController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Company>> GetAll()
        {
            try
            {
                return _context.Companies.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Company company)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, company, BasicQuery.Company);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Company.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Company company)
        {

            try
            {
                BasicQuery.Update(_context,company, BasicQuery.Company);
                return StatusCode(200, "Update into Company succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Company.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.Company);
                return StatusCode(200, "Delete into Company succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Company.\n" + ex.Message);
            }
        }
    }
}

