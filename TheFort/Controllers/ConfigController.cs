using BackOffice.Models;
using Microsoft.AspNetCore.Mvc;

namespace TheFort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new WireConfig() { Jitter = 3000 });
        }
    }
}