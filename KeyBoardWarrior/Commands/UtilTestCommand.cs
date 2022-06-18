using System.Net.Http.Json;
using BackOffice;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace KeyBoardWarrior.Commands
{
    [Command("test", Description = "Test command")]
    public class UtilTestCommand : ICommand
    {

        public async ValueTask ExecuteAsync(IConsole console)
        {
            OS.GetProcesses();
        }
    }
}