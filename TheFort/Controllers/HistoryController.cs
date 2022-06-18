using BackOffice.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace TheFort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        [HttpGet("get-all")]
        public IActionResult GetAllResponses()
        {
            using (var db = new LiteDatabase("/home/sam/db/fort.db"))
            {
                var col = db.GetCollection<WireResponse>("wireResponses");
                var results = col.FindAll().ToList();
                return Ok(results);
            }
        }
    }
}