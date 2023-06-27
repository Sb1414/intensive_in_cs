namespace team01.WeatherRequests.Models;

using System.Text.Json.Serialization;

public class WeatherForecast
{
    public Wind Wind { get; set; }
    public List<Weather> Weather { get; set; }
    public MainInfo Main { get; set; }
    public string Name { get; set; }
}

public class Wind
{
    public double Speed { get; set; }
}

public class Weather
{
    public string Description { get; set; }
}

public class MainInfo
{
    public double Temp { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}