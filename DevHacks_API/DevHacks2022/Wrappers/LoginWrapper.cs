using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHacks2022.Wrappers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class LoginWrapper
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
