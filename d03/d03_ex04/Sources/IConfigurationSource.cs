namespace d03_ex04.Sources;

internal interface IConfigurationSource
{
    int Priority { get; }
    Dictionary<string, object> LoadParameters();
}
