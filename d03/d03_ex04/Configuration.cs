using d03_ex04.Sources;

namespace d03_ex04;

internal class Configuration
{
    public Dictionary<string, object>? Params;
    public Configuration(IEnumerable<IConfigurationSource> sources)
    {
        Params = new Dictionary<string, object>();

        // Вызываем метод для объединения параметров
        MergeParameters(sources);
    }

    public string? GetParameter(string key)
    {
        if (Params.ContainsKey(key))
        {
            return Params[key]?.ToString();
        }
        return null;
    }
    
    private void MergeParameters(IEnumerable<IConfigurationSource> sources)
    {
        foreach (var source in sources)
        {
            var parameters = source.LoadParameters();
            foreach (var parameter in parameters)
            {
                if (!Params.ContainsKey(parameter.Key))
                {
                    Params[parameter.Key] = parameter.Value;
                }
            }
        }
    }

}
