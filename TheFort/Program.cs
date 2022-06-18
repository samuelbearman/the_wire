using TheFort;
using TheFort.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<WireTaskQueue>();
builder.Services.Configure<FortConfig>(builder.Configuration.GetSection(FortConfig.Config));

var app = builder.Build();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine("Fort is up and operational");
app.Run();
