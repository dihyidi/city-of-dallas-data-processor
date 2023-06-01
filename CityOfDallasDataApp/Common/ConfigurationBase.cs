using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CityOfDallasDataApp.Common;

public abstract class ConfigurationBase<TType> where TType:Enum
{
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public TType Type { get; set; }

    public Dictionary<string, string> Args { get; set; }
}