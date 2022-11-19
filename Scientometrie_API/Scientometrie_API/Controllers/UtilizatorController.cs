using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Scientometrie_API.Utils;
using Scientometrie_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Wrappers;
using Microsoft.AspNetCore.Cors;

namespace Scientometrie_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        private ScientometrieDbContext _context;

        public UtilizatorController(ScientometrieDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Utilizator>> GetAll()
        {
            try
            {
                return _context.Utilizator.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Match")]
        public ActionResult<Utilizator> GetUtilizator_Portivire(string numeUtilizator)
        {
            try
            {
                var utilizatori = UtilizatorQuery.Match(_context, numeUtilizator);
                return Ok(utilizatori);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("VerifyCode")]
        public IActionResult VerifyCode(int ID, string Code)
        {
            try
            {
                UtilizatorQuery.VerifyCode(_context, ID, Code);
                return StatusCode(200, "Code is correct! You can change your password");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginWrapper wrapper)
        {
            try
            {
                dynamic response = UtilizatorQuery.Login(_context, wrapper.numeUtilizator, wrapper.parola);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Utilizator Utilizator)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Utilizator, BasicQuery.UTILIZATOR);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GenerateCode")]
        public IActionResult GenereateCode([FromBody] string Email)
        {
            try
            {
                var response=UtilizatorQuery.GenerateCode(_context, Email);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("ChangePassowrd")]  
        public IActionResult ChangePassowrd(int ID,[FromBody]string parola)
        {
            try
            {
                UtilizatorQuery.ChangePassword(_context, ID, parola);
                return StatusCode(200, "Code is correct! You can change your password");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpPut("Put")]
        public IActionResult Put([FromBody] Utilizator Utilizator)
        {
            try
            {
                BasicQuery.Update(_context, Utilizator, BasicQuery.UTILIZATOR);
                return StatusCode(200, "Update into Utilizator succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Update into Utilizator.\n" + ex.Message);
            }
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int ID)
        {
            try
            {
                BasicQuery.Delete(_context, ID, BasicQuery.UTILIZATOR);
                return StatusCode(200, "Delete into Utilizator succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Utilizator.\n" + ex.Message);
            }
        }
    }
}
