using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : Controller
    {
        private ScientometrieDbContext _context;

        public AutorController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Autor>> GetAll()
        {
            try
            {
                return _context.Autor.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetUnaccredited")]
        public ActionResult<IEnumerable<Autor>> GetUnaccredited()
        {
            try
            {
                var autori = AutorQuery.GetUnaccredited(_context);
                return autori;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Autor Autor)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Autor, BasicQuery.AUTOR);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Insert into Autor.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Autor Autor)
        {

            try
            {
                BasicQuery.Update(_context, Autor, BasicQuery.AUTOR);
                return StatusCode(200, "Update into Autor succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Autor.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.AUTOR);
                return StatusCode(200, "Delete into Utilizator succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Autor.\n" + ex.Message);
            }
        }
    }
}
