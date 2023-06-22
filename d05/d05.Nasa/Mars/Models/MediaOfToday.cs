using System.Globalization;
using System.Text.Json.Serialization;

namespace d05.Nasa.Mars.Models;

public class MediaOfTodayMars
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("sol")]
    public int Sol { get; set; }

    [JsonPropertyName("camera")]
    public CameraInfo Camera { get; set; }

    [JsonPropertyName("img_src")]
    public string ImageSource { get; set; }

    [JsonPropertyName("earth_date")]
    public DateTime EarthDate { get; set; }

    [JsonPropertyName("rover")]
    public RoverInfo Rover { get; set; }

    public override string ToString()
    {
        return $"EarthDate: {EarthDate.ToString("dd'/'MM'/'yyyy", new CultureInfo("en-GB"))}\n" +
               $"{Camera.ToString()}\n" +
               $"{Rover.ToString()}" +
               $"Id: {Id}\n" +
               $"ImageSource: {ImageSource}\n";
    }
}

public class MediaOfTodayMarsWrapper
{
    [JsonPropertyName("photos")]
    public MediaOfTodayMars[] Photos { get; set; }
}

public class CameraInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rover_id")]
    public int RoverId { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName { get; set; }
    
    public override string ToString()
    {
        return $"CameraInfo:\n" +
               $"   id={Id}, Name=‘{Name}’, RoverId={RoverId}, FullName={FullName}";
    }
}

public class RoverInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("landing_date")]
    public DateTime LandingDate { get; set; }

    [JsonPropertyName("launch_date")]
    public DateTime LaunchDate { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    public override string ToString()
    {
        return $"RoverInfo:" +
               $"   LandingDate: {LandingDate.ToString("dd'/'MM'/'yyyy", new CultureInfo("en-GB"))}\n" +
               $"   LaunchDate: {LaunchDate.ToString("dd'/'MM'/'yyyy", new CultureInfo("en-GB"))}\n" +
               $"   Name: ‘{Name}’\n" +
               $"   Id: {Id}\n" +
               $"   Status: {Status}\n";
    }
}