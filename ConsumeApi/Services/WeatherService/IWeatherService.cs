namespace ConsumeApi.Services.WeatherService;

public interface IWeatherService
{
    Task<string> Get(string cityName);
}

