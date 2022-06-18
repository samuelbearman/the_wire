using System.Collections.Concurrent;
using BackOffice.Models;

namespace TheFort.Services
{
    public class WireTaskQueue
    {
        private readonly ConcurrentQueue<WireTask> _queue
        = new ConcurrentQueue<WireTask>();

        public ConcurrentQueue<WireTask> Queue => _queue;
    }
}