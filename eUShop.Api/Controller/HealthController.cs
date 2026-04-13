using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eUShop.Api.Controller
{
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult Get()
        {
            return Ok("Healthy");
        }
    }
}
