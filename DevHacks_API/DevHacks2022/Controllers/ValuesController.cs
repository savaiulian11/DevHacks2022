using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("Test")]
        public IActionResult actionResult()
        {
            return Ok("Salve");
        }
    }
}
