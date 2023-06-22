using System.Net;
using System.Text.Json;
using d05.Nasa.Mars.Models;

namespace d05.Nasa.Mars;

public class MarsClient : INasaClient<int, Task<MediaOfTodayMars[][]>>
{
    private readonly string apiKey;
    private readonly HttpClient httpClient;

    public MarsClient(string apiKey)
    {
        this.apiKey = apiKey;
        this.httpClient = new HttpClient();
    }

    public async Task<MediaOfTodayMars[][]> GetAsync(int sol)
    {
        try
        {
            string apiUrl = $"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol={sol}&api_key={apiKey}";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var wrapper = JsonSerializer.Deserialize<MediaOfTodayMarsWrapper>(responseContent);

                return new MediaOfTodayMars[][] { wrapper.Photos };
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