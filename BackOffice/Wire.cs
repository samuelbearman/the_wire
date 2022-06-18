namespace BackOffice.Models
{
    public class WireTask
    {
        public Guid Id { get; set; }
        public string Command { get; set; }
        public string Args { get; set; }
    }

    public class WireResponse
    {
        public Guid Id { get; set; }
        public string Output { get; set; }
    }

    public class WireConfig
    {
        public int Jitter { get; set; }
    }

    public class NewWireTaskCommand 
    {
        public string Command { get; set; }
        public string Args { get; set; }
    }
}