using CityOfDallasDataApp;
using CityOfDallasDataApp.Common;
using CityOfDallasDataApp.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false)
    .Build();

var services = new ServiceCollection();

services.Configure<InputConfiguration>(config =>
{
    configuration.GetSection("Input").Bind(config);
});
services.Configure<OutputConfiguration>(config =>
{
    configuration.GetSection("Output").Bind(config);
    
});

services.AddSingleton<ReaderFactory>();
services.AddSingleton<WriterFactory>();

var serviceProvider = services.BuildServiceProvider();

var readerFactory = serviceProvider.GetService<ReaderFactory>();
var writerFactory = serviceProvider.GetService<WriterFactory>();

// Use the service
var reader = readerFactory?.Create();
var writer = writerFactory?.Create();

var data = await reader?.ReadData<ExpenseModel>();
await writer?.WriteData(data);