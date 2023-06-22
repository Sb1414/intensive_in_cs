using System.Net;
using System.Text.Json;
using d05.Nasa.Earth.Models;

namespace d05.Nasa.Earth;

public class EarthClient : INasaClient<EarthRequest, Task<MediaOfTodayEarth[]>>
{
    private readonly string apiKey;
    private readonly HttpClient httpClient;

    public EarthClient(string apiKey)
    {
        this.apiKey = apiKey;
        this.httpClient = new HttpClient();
    }

    public async Task<MediaOfTodayEarth[]> GetAsync(EarthRequest request)
    {
        try
        {
            string apiUrl = $"https://api.nasa.gov/planetary/earth/assets?lon={request.Longitude}&lat={request.Latitude}&date={request.Date.ToString("yyyy-MM-dd")}&&dim={request.Dimensions}&api_key={apiKey}";
            // https://api.nasa.gov/planetary/earth/assets?lon=-95,33&lat=29,78&date=2018-01-01&dim=0,1&api_key=aUefrscvDf536ydo8OQP7F2zkmFPx2ezVK7N1dFg
            // https://api.nasa.gov/planetary/earth/assets?lon=-95.33&lat=29.78&date=2018-01-01&&dim=0.10&api_key=aUefrscvDf536ydo8OQP7F2zkmFPx2ezVK7N1dFg
            var response = await httpClient.GetAsync(apiUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(responseContent); // Выводим содержимое ответа на консоль
                
                var mediaOfToday = JsonSerializer.Deserialize<MediaOfTodayEarth>(responseContent);
                return new MediaOfTodayEarth[] { mediaOfToday };
            }
            else
            {
                Console.WriteLine($"GET \"{apiUrl}\" returned {response.StatusCode}:\n{await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return null;
    }
}