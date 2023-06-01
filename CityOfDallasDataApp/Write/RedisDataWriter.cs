using Newtonsoft.Json;
using StackExchange.Redis;

namespace CityOfDallasDataApp.Write;

public class RedisDataWriter : IDataWriter
{
    private readonly IConnectionMultiplexer connectionMultiplexer;
    private readonly long cacheExpireInSeconds;

    public RedisDataWriter(string connectionString, long cacheExpireInSeconds)
    {
        this.connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        this.cacheExpireInSeconds = cacheExpireInSeconds;
    }
    
    public async Task<bool> WriteData<T>(IEnumerable<T> data)
    {
        if (data is null)
        {
            return false;
        }

        var json = JsonConvert.SerializeObject(data);
        var key = $"DallasExpenses_{DateTime.Now.ToFileTime()}";

        var db = this.connectionMultiplexer.GetDatabase();
        try
        {
            var success =  await db.StringSetAsync(key, json, TimeSpan.FromSeconds(this.cacheExpireInSeconds));
            if (success)
            {
                Console.WriteLine("KEY: " + key);
                var writtenData = JsonConvert.DeserializeObject<IEnumerable<T>>(db.StringGet(key));
                foreach (var item in writtenData)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            return success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}