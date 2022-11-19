using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipPublicatieController : Controller
    {
        private ScientometrieDbContext _context;

        public TipPublicatieController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<TipPublicatie>> GetAll()
        {
            try
            {
                return _context.TipPublicatie.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] TipPublicatie TipPublicatie)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, TipPublicatie, BasicQuery.TIPPUBLICATIE);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into TipPublicatie.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] TipPublicatie TipPublicatie)
        {
            try
            {
                BasicQuery.Update(_context, TipPublicatie, BasicQuery.TIPPUBLICATIE);
                return StatusCode(200, "Update into TipPublicatie succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into TipPublicatie.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.TIPPUBLICATIE);
                return StatusCode(200, "Delete into Utilizator succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into TipPublicatie.\n" + ex.Message);
            }
        }
    }
}
