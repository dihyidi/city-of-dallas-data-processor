using CityOfDallasDataApp.Common;
using CityOfDallasDataApp.Read;
using Microsoft.Extensions.Options;

namespace CityOfDallasDataApp.Factories;

public class ReaderFactory
{
    private readonly InputConfiguration config;
    
    public ReaderFactory(IOptions<InputConfiguration> options)
    {
        this.config = options.Value;
    }

    public IDataReader Create()
    {
        return config.Type switch
        {
            InputType.Api => new ApiDataReader(config.Args["BaseUrl"], config.Args["Uri"]),
            InputType.Csv => new CsvDataReader(config.Args["FilePath"]),
            _ => null
        };
    }
}