using BackOffice.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TheFort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly FortConfig _config;
        public HistoryController(IOptions<FortConfig> config)
        {
            _config = config.Value;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllResponses()
        {
            using (var db = new LiteDatabase(_config.DBPath))
            {
                var col = db.GetCollection<WireResponse>("wireResponses");
                var results = col.FindAll().ToList();
                return Ok(results);
            }
        }
    }
}