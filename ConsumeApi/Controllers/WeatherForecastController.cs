using ConsumeApi.Services.WeatherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeApi.Controllers;

[ApiController]
[Route("[controller]"), Authorize]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<string> Get(string cityName)
    {

        return await _weatherService.Get(cityName);

    }
}
