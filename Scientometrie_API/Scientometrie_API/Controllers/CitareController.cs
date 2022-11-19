using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitareController : Controller
    {
        private ScientometrieDbContext _context;

        public CitareController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Citare>> GetAll()
        {
            try
            {
                return _context.Citare.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Citare Citare)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Citare, BasicQuery.CITARE);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Citare.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Citare Citare)
        {

            try
            {
                BasicQuery.Update(_context, Citare, BasicQuery.CITARE);
                return StatusCode(200, "Update into Citare succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Citare.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.CITARE);
                return StatusCode(200, "Delete into Utilizator succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Citare.\n" + ex.Message);
            }
        }
    }
}
