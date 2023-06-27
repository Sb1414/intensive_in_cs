using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using team01.WeatherRequests.Models;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using team01.WeatherRequests;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace team01.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class  WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration _configuration;
    private readonly WeatherClient _weatherClient;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)//, WeatherClient client)
    {
        _logger = logger;
        _configuration = configuration;
        _weatherClient = new WeatherClient(configuration); //client;
    }

    // public WeatherForecastController(IHttpClientFactory httpClientFactory)
    // {
    //     //_httpClient = httpClientFactory.CreateClient();
    //     _httpClient = new HttpClient();
    // }

    // public async Task<WeatherForecast> MakeWeatherByCoordinates(double latitude, double longitude)
    // {
    //     Console.WriteLine("HEHEHEHEHEHEHEHEHE");
    //     string apiKey = "b16edb189d757b856c11599ec2e1718a";
    //     string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";
    //     return await MakeResponse(apiUrl);
    // }

    // private async Task<WeatherForecast>MakeResponse(string apiUrl)
    // {
    //     HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
    //     string json = await response.Content.ReadAsStringAsync();
    //     if (!response.IsSuccessStatusCode)
    //          throw new Exception($"GET {apiUrl} - {response.StatusCode}\n{json}");
    //
    //      WeatherForecast weatherData = JsonConvert.DeserializeObject<WeatherForecast>(json);
    //     return weatherData;
    //
    // }

    /// <summary>
    /// Get weather forecast for the specified coordinates.
    /// </summary>
    /// <param name="latitude">Latitude of the location.</param>
    /// <param name="longitude">Longitude of the location.</param>
    /// <returns>Weather information for the specified location.</returns>
    /// <response code="200">Returns the weather information.</response>
    /// <response code="400">If the coordinates are invalid or an error occurred.</response>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(double latitude, double longitude)
    {
        try
        {
            return Ok(await _weatherClient.GetWeatherByCoordinates(latitude,  longitude));
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Get weather forecast for the specified city.
    /// </summary>
    /// <param name="cityName">Name of the city.</param>
    /// <returns>Weather information for the specified city.</returns>
    /// <response code="200">Returns the weather information.</response>
    /// <response code="400">If the city name is invalid or an error occurred.</response>
    [HttpGet("{cityName}", Name = "GetWeatherForecastByCity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByCity(string cityName)
    {
        try
        {
            return Ok(await _weatherClient.GetWeatherByCity(cityName));
        }
        catch
        {
            return BadRequest();
        }
    }

}


