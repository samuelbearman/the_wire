using System.Net.Http.Json;
using BackOffice.Models;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace KeyBoardWarrior.Commands
{
    [Command("history", Description = "Get History of all commands and output")]
    public class HistoryCommand : ICommand
    {
        public async ValueTask ExecuteAsync(IConsole console)
        {
            var client = new HttpClient();

            var result = await client.GetFromJsonAsync<List<WireResponse>>("http://localhost:5070/history/get-all");
            foreach (var response in result)
            {
                console.Output.WriteLine($"Id: {response.Id}\nOutput: \n\n{response.Output}\n");
            }
        }
    }
}