namespace CityOfDallasDataApp.Read;

public interface IDataReader
{
    Task<IEnumerable<T>> ReadData<T>();
}