namespace ConsumeApi.Services.WeatherService;

public class WeatherService : IWeatherService
{
    private HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> Get(string cityName)
    {
        var apiKey = "254970bdba1b4fc0b4c222531222203";

        string APIURL = $"?key={apiKey}&q={cityName}";
        var response = await _httpClient.GetAsync(APIURL);
        return await response.Content.ReadAsStringAsync();
    }
}