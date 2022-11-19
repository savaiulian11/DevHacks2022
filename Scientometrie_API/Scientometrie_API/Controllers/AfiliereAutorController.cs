using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliereAutorController : Controller
    {
        private ScientometrieDbContext _context;

        public AfiliereAutorController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<AfiliereAutor>> GetAll()
        {
            try
            {
                return _context.AfiliereAutor.ToList();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] AfiliereAutor AfiliereAutor)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, AfiliereAutor, BasicQuery.AFILIEREAUTOR);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into AfiliereAutor.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] AfiliereAutor AfiliereAutor)
        {

            try
            {
                BasicQuery.Update(_context, AfiliereAutor, BasicQuery.AFILIEREAUTOR);
                return StatusCode(200, "Update into AfiliereAutor succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into AfiliereAutor.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.AFILIEREAUTOR);
                return StatusCode(200, "Delete into AfiliereAutor succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into AfiliereAutor.\n" + ex.Message);
            }
        }
    }
}
