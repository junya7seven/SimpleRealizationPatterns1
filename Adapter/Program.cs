
// Standart service for getting values
public interface IWeatherService
{
    string GetTemperature();
    string GetCondition();
}
// anuther servic with unique values
public interface IWeatherServiceYandex
{
    string GetTemperature();
    string GetCondition();
    string GetWindSpeed();
}
// Adapter for converting the interface of a third-party service
public class WeatherServiceYandexAdapter : IWeatherService
{
    private readonly IWeatherServiceYandex weatherServiceYandex;
    public WeatherServiceYandexAdapter(IWeatherServiceYandex weatherServiceYandex)
    {
        this.weatherServiceYandex = weatherServiceYandex;
    }
    // Method Call Conversion
    public string GetTemperature()
    {
        return weatherServiceYandex.GetTemperature();
    }
    //Method Call Conversion
    public string GetCondition()
    {
        return weatherServiceYandex.GetCondition();
    }
    public string GetWindSpeed()
    {
        return weatherServiceYandex.GetWindSpeed();
    }
}
// Client code use standart interface
public class WeatherClietn
{
    private readonly IWeatherService weatherService;
    public WeatherClietn(IWeatherService weatherService)
    {
        this.weatherService = weatherService;
    }
    public void Display()
    {
        Console.WriteLine($"T - {weatherService.GetTemperature()}");
        Console.WriteLine($"C - {weatherService.GetCondition()}");
        if (weatherService is WeatherServiceYandexAdapter adapter)
        {
            Console.WriteLine($"Wind Speed: {adapter.GetWindSpeed()}");
        }
        else
        {
            Console.WriteLine("No info");
        }
    }
}
// Realization another serivec
public class WeatherServiceYandex : IWeatherServiceYandex
{
    public string GetTemperature()
    {
        return "25C";
    }
    public string GetCondition()
    {
        return "Rain";
    }
    public string GetWindSpeed()
    {
        return "10 m/s";
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create instance another service
        IWeatherServiceYandex weatherServiceYandex = new WeatherServiceYandex();
        // Create adapter for standart service
        IWeatherService adapter = new WeatherServiceYandexAdapter(weatherServiceYandex);
        // Client uses a standart interface throught adapter
        WeatherClietn client = new WeatherClietn(adapter);
        client.Display();
    }
}