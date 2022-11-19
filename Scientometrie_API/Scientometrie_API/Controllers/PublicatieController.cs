using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using Scientometrie_API.Utils;

namespace Scientometrie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicatieController : Controller
    {
        private ScientometrieDbContext _context;

        public PublicatieController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Publicatie>> GetAll()
        {
            try
            {
                return _context.Publicatie.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Publicatie Publicatie)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Publicatie, BasicQuery.PUBLICATIE);
                return StatusCode(200, result);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Error Insert into Publicatie.\n" + ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] Publicatie Publicatie)
        {

            try
            {
                BasicQuery.Update(_context, Publicatie, BasicQuery.PUBLICATIE);
                return StatusCode(200, "Update into Publicatie succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Publicatie.\n" + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.PUBLICATIE);
                return StatusCode(200, "Delete into Publicatie succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Publicatie.\n" + ex.Message);
            }
        }
    }
}
