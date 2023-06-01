namespace CityOfDallasDataApp.Write;

public interface IDataWriter
{
    Task<bool> WriteData<T>(IEnumerable<T> data);
}