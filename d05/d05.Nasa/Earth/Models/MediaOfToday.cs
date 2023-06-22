using System.Globalization;
using System.Text.Json.Serialization;

namespace d05.Nasa.Earth.Models;

public class MediaOfTodayEarth
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("resource")]
    public Resource Resource { get; set; }

    public override string ToString()
    {
        return $"{Date.ToString("dd'/'MM'/'yyyy", new CultureInfo("en-GB"))}\n" +
               $"‘{Id}’\n" +
               $"{Url}\n";
    }
}

public class Resource
{
    [JsonPropertyName("dataset")]
    public string Dataset { get; set; }

    [JsonPropertyName("planet")]
    public string Planet { get; set; }
}