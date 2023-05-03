using System.Text.Json;
using HTGR.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapGet("/sessions", () =>
{
    return JsonSerializer.Deserialize<SessionModel[]>(File.ReadAllText($"{Environment.CurrentDirectory}/Data/daythree.json"));
});

app.Run();