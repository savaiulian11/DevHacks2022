using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mail;
using System.Net;
using DevHacks2022.Utils;
using DevHacks2022.Models;
using DevHacks2022.Wrappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Microsoft.AspNetCore.Cors;

namespace DevHacks2022.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DevHacks2022Context _context;

        public UsersController(DevHacks2022Context context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Match")]
        public ActionResult<User> GetUtilizator_Portivire(string numeUtilizator)
        {
            try
            {
                var utilizatori = UsersQuery.Match(_context, numeUtilizator);
                return Ok(utilizatori);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("VerifyCode")]


        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginWrapper wrapper)
        {
            try
            {
                dynamic response = UsersQuery.Login(_context, wrapper.Username, wrapper.Password);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] User Utilizator)
        {
            try
            {
                dynamic result = BasicQuery.Insert(_context, Utilizator, BasicQuery.Users);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("ChangePassowrd")]
        public IActionResult ChangePassowrd(int ID, [FromBody] string parola)
        {
            try
            {
                UsersQuery.ChangePassword(_context, ID, parola);
                return StatusCode(200, "Code is correct! You can change your password");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] User Utilizator)
        {
            try
            {
                BasicQuery.Update(_context, Utilizator, BasicQuery.Users);
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
                BasicQuery.Delete(_context, ID, BasicQuery.Users);
                return StatusCode(200, "Delete into Utilizator succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Delete into Utilizator.\n" + ex.Message);
            }
        }
    }
}