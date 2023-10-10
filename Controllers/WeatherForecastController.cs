using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SSEExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    [HttpGet("eventstream")]
    public async Task<IActionResult> EventStream(CancellationToken cancellationToken)
    {
        Response.Headers.Add("Content-Type", "text/event-stream");
        var random = new Random();

        while (!cancellationToken.IsCancellationRequested)
        {
            var data = new
            {
                message = $"Hello from the server {Guid.NewGuid()}!",
                timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var jsonData = JsonSerializer.Serialize(data);
            var eventString = $"data: {jsonData}\n\n";

            await Response.WriteAsync(eventString);
            await Response.Body.FlushAsync();
            await Task.Delay(random.Next(1000, 5000), cancellationToken);
        }

        return new EmptyResult();
    }
}
