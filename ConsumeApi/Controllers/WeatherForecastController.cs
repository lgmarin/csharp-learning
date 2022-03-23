using ConsumeApi.Services.WeatherService;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeApi.Controllers;

[ApiController]
[Route("[controller]")]
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
        // var URL = $"?key=254970bdba1b4fc0b4c222531222203&q={cityName}&aqi=no";
        
        // // Reuse connections to the external API
        // var httpClient = _httpClientFactory.CreateClient("weather");

        // var response = await httpClient.GetAsync(URL);
        
        // return await response.Content.ReadAsStringAsync();


        // using (var httpClient = new HttpClient())
        // {
        //     var response = await httpClient.GetAsync(URL);
            
        //     return await response.Content.ReadAsStringAsync();
        // } SOLVES Multiple Socket problem for each request, but for different ?q it generates another socket MULTIPLE SOCKET PROBLEM

        return await _weatherService.Get(cityName);

    }
}
