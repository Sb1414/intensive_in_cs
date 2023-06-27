using System.Text.Json;
using Microsoft.Extensions.Configuration;
using team01.WeatherRequests.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace team01.WeatherRequests;

public class WeatherClient
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private readonly string _apiKey;
    public WeatherClient(IConfiguration configuration)
    {
        _apiKey = configuration["ApiKey"];
    }
    
    public async Task<WeatherForecast> GetWeatherByCoordinates(double latitude, double longitude)
    {
        string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={_apiKey}&units=metric";
        return await MakeResponse(apiUrl);
    }
    
    public async Task<WeatherForecast> GetWeatherByCity(string cityName)
    {
        string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric";
        return await MakeResponse(apiUrl);
    }
    
    private async Task<WeatherForecast>MakeResponse(string apiUrl)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        string json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception($"GET {apiUrl} - {response.StatusCode}\n{json}");
        
        WeatherForecast weatherData = JsonSerializer.Deserialize<WeatherForecast>(json,new JsonSerializerOptions 
        {
            PropertyNameCaseInsensitive = true
        });

        var weatherResponse = new WeatherForecast
        {
            Wind = new Wind { Speed = weatherData.Wind.Speed },
            Weather = new List<Weather> { new Weather { Description = weatherData.Weather[0].Description } },
            Main = new MainInfo { Temp = weatherData.Main.Temp, Pressure = weatherData.Main.Pressure, Humidity = weatherData.Main.Humidity },
            Name = weatherData.Name
        };
        return weatherResponse;
    
    }
}
