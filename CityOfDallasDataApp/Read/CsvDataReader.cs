using System.Globalization;
using CsvHelper;

namespace CityOfDallasDataApp.Read;

public class CsvDataReader : IDataReader
{
    private readonly string filePath;

    public CsvDataReader(string filePath)
    {
        this.filePath = filePath;
    }

    public async Task<IEnumerable<T>> ReadData<T>()
    {
        if (!File.Exists(filePath))
        {
            return Enumerable.Empty<T>();
        }

        using var streamReader = new StreamReader(filePath);
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        var csvModels = csvReader.GetRecordsAsync<T>();

        if (csvModels == null)
        {
            return Enumerable.Empty<T>();
        }

        var models = new List<T>();

        await foreach (var model in csvModels)
        {
            models.Add(model);
        }

        return models;
    }
}