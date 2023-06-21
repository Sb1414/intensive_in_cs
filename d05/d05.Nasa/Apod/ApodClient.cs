using System.Text.Json;
using d05.Nasa.Apod.Models;

namespace d05.Nasa.Apod;

public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
{
    private readonly string apiKey;
    private readonly HttpClient httpClient;

    public ApodClient(string apiKey)
    {
        this.apiKey = apiKey;
        this.httpClient = new HttpClient();
    }

    public async Task<MediaOfToday[]> GetAsync(int count)
    {
        try
        {
            string apiUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&count={count}";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var mediaOfTodayList = JsonSerializer.Deserialize<List<MediaOfToday>>(responseContent);

                return mediaOfTodayList.ToArray();
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