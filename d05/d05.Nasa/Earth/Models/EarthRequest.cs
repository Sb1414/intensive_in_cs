namespace d05.Nasa.Earth.Models;

public class EarthRequest
{
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public DateTime Date { get; set; }
    public string Dimensions { get; set; }
}