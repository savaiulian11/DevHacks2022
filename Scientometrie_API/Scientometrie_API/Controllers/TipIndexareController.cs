using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipIndexareController : Controller
    {
        private ScientometrieDbContext _context;

        public TipIndexareController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<TipIndexare>> GetAll()
        {
            try
            {
                return _context.TipIndexare.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] TipIndexare TipIndexare)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, TipIndexare, BasicQuery.TIPINDEXARE);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into TipIndexare.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] TipIndexare TipIndexare)
        {

            try
            {
                BasicQuery.Update(_context, TipIndexare, BasicQuery.TIPINDEXARE);
                return StatusCode(200, "Update into TipIndexare succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into TipIndexare.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.TIPINDEXARE);
                return StatusCode(200, "Delete into TipIndexare succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into TipIndexare.\n" + ex.Message);
            }
        }
    }
}
