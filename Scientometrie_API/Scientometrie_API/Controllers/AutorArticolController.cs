using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorArticolController : Controller
    {
        private ScientometrieDbContext _context;

        public AutorArticolController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<AutorArticol>> GetAll()
        {
            try
            {
                return _context.AutorArticol.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] AutorArticol AutorArticol)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, AutorArticol, BasicQuery.AUTORARTICOL);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into AutorArticol.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] AutorArticol AutorArticol)
        {

            try
            {
                BasicQuery.Update(_context, AutorArticol, BasicQuery.AUTORARTICOL);
                return StatusCode(200, "Update into AutorArticol succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error AutorArticol into AutorArticol.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.AUTORARTICOL);
                return StatusCode(200, "Delete into AutorArticol succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into AutorArticol.\n" + ex.Message);
            }
        }
    }
}
