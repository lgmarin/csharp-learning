using Microsoft.AspNetCore.Mvc;

namespace ConsumeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private static HttpClient _httpClient;

    static WeatherForecastController()
    {
        // It is created only one time when the app runs
        _httpClient = new HttpClient();
    }

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<string> Get(string cityName)
    {
        var URL = $"http://api.weatherapi.com/v1/current.json?key=254970bdba1b4fc0b4c222531222203&q={cityName}&aqi=no";
        
        var response = await _httpClient.GetAsync(URL);
        
        return await response.Content.ReadAsStringAsync();


        // using (var httpClient = new HttpClient())
        // {
        //     var response = await httpClient.GetAsync(URL);
            
        //     return await response.Content.ReadAsStringAsync();
        // } SOLVES Multiple Socket problem for each request, but for different ?q it generates another socket MULTIPLE SOCKET PROBLEM


    }
}
