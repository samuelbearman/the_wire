using BackOffice.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TheFort.Services;

namespace TheFort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly WireTaskQueue _queue;
        private readonly FortConfig _config;

        public TasksController(WireTaskQueue queue, IOptions<FortConfig> config)
        {
            _queue = queue;
            _config = config.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            WireTask nextWireTask = null;
            _queue.Queue.TryDequeue(out nextWireTask);
            if (nextWireTask != null)
            {
                return Ok(nextWireTask);
            }
            else
            {
                return Ok(new { Id = Guid.Empty });
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] WireResponse response)
        {
            using (var db = new LiteDatabase(_config.DBPath))
            {
                var col = db.GetCollection<WireResponse>("wireResponses");
                col.Insert(response);
            }
            return Ok(response.Output);
        }

        [HttpPost("new-task")]
        public IActionResult NewTask([FromBody] NewWireTaskCommand command)
        {
            var newTask = new WireTask() { Id = Guid.NewGuid(), Command = command.Command, Args = command.Args };
            _queue.Queue.Enqueue(newTask);
            using (var db = new LiteDatabase(_config.DBPath))
            {
                var col = db.GetCollection<WireTask>("wireTasks");
                col.Insert(newTask);
            }
            return Ok();
        }
    }
}