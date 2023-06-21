using System.Globalization;
using System.Text.Json.Serialization;

namespace d05.Nasa.Apod.Models;

public class MediaOfToday
{
    [JsonPropertyName("copyright")] public string Copyright { get; set; }
    [JsonPropertyName("date")] public DateTime Date { get; set; }
    [JsonPropertyName("explanation")] public string Explanation { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }
    
    public void ReplaceNewLinesInCopyright()
    {
        Copyright = Copyright?.Replace("\n", " ");
        Copyright = Copyright?.Trim(' ');
    }

    public override string ToString()
    {
        ReplaceNewLinesInCopyright();
        return $"{Date.ToString("dd'/'MM'/'yyyy", new CultureInfo("en-GB"))}\n" +
            $"‘{Title}’ " + $"{(string.IsNullOrEmpty(Copyright) ? "" : $"by {Copyright}")}\n" +
            $"{Explanation}\n{Url}\n";
    }
}