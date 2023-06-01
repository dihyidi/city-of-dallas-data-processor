namespace CityOfDallasDataApp.Write;

public class ConsoleDataWriter : IDataWriter
{
    public Task<bool> WriteData<T>(IEnumerable<T> data)
    {
        foreach (var item in data)
        {
            Console.WriteLine(item.ToString());
        }
        return Task.FromResult(true);
    }
}