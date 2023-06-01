using CityOfDallasDataApp.Common;
using CityOfDallasDataApp.Write;
using Microsoft.Extensions.Options;

namespace CityOfDallasDataApp.Factories;

public class WriterFactory
{
    private readonly OutputConfiguration config;
    
    public WriterFactory(IOptions<OutputConfiguration> options)
    {
        this.config = options.Value;
    }

    public IDataWriter Create()
    {
        return config.Type switch
        {
            OutputType.Console => new ConsoleDataWriter(),
            OutputType.Redis => new RedisDataWriter(config.Args["ConnectionString"], int.Parse(config.Args["Timeout"])),
            _ => null
        };
    }
}