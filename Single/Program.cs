// Single for control settings app
public sealed class ConfigurationManager // От класса нельзя наследоваться
{
    // Single instance
    private static readonly Lazy<ConfigurationManager> instance = new Lazy<ConfigurationManager>(() => new ConfigurationManager());
    // Dictionary for save settings
    private Dictionary<string, string> settings;
    // private constructor
    private ConfigurationManager()
    {
        settings = new Dictionary<string, string>();
    }
    // Global access point to the instance
    public static ConfigurationManager Instance
    {
        get { return instance.Value; }
    }
    // Add or update settings
    public void SetSetting(string key, string value)
    {
        if (settings.ContainsKey(key))
        {
            settings[key] = value;
        }
        else
        {
            settings.Add(key, value);
        }
    }
    // Get values setting by key
    public string GetSetting(string key)
    {
        return settings.ContainsKey(key) ? settings[key] : null;
    }
    // Demonstration settings
    public void DisplaySettings()
    {
        Console.WriteLine("Current Settings");
        foreach (var setting in settings)
        {
            Console.WriteLine($"{setting.Key} : {setting.Value}");
        }
    }
}
// Client
class Program
{
    static void Main(string[] args)
    {
        // Getting an instance ConfigurationManager
        ConfigurationManager configManager = ConfigurationManager.Instance;
        // Set settings
        configManager.SetSetting("LogLevel", "Debug");
        configManager.SetSetting("MaxConnections", "100");
        configManager.DisplaySettings();
        // Second request 
        ConfigurationManager anotherConfigManager = ConfigurationManager.Instance;
        // Check
        Console.WriteLine($"{configManager == anotherConfigManager}"); // если экземпляры одинаковы True 
    }
}