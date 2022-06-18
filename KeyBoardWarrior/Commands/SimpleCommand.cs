using System.Net.Http.Json;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace KeyBoardWarrior.Commands
{
    [Command("simple", Description = "Issue simple command")]
    public class SimpleCommand : ICommand
    {
        [CommandParameter(0, IsRequired = true)]
        public string Command { get; set; }

        [CommandParameter(1, IsRequired = false)]
        public string Arguments { get; set; }

        public async ValueTask ExecuteAsync(IConsole console)
        {
            var client = new HttpClient();

            await client.PostAsJsonAsync("http://localhost:5070/tasks/new-task", new {command = Command, args = Arguments});
        }
    }
}