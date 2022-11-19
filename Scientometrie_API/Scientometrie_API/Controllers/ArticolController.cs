using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticolController : ControllerBase
    {
        private ScientometrieDbContext _context;

        public ArticolController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Articol>> GetAll()
        {
            try
            {
                return _context.Articol.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Articol Articol)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Articol, BasicQuery.ARTICOL);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Articol.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Articol Articol)
        {

            try
            {
                BasicQuery.Update(_context, Articol, BasicQuery.ARTICOL);
                return StatusCode(200, "Update into Articol succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Articol.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.ARTICOL);
                return StatusCode(200, "Delete into Articol succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Articol.\n" + ex.Message);
            }
        }
    }
}
