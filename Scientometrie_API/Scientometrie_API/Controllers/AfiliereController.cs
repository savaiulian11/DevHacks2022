using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliereController : Controller
    {
        private ScientometrieDbContext _context;

        public AfiliereController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Afiliere>> GetAll()
        {
            try
            {
                return _context.Afiliere.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Afiliere Afiliere)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Afiliere, BasicQuery.AFILIERE);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Afiliere.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Afiliere Afiliere)
        {

            try
            {
                BasicQuery.Update(_context, Afiliere, BasicQuery.AFILIERE);
                return StatusCode(200, "Update into Afiliere succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Afiliere.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.AFILIERE);
                return StatusCode(200, "Delete into Afiliere succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Afiliere.\n" + ex.Message);
            }
        }
    }
}
