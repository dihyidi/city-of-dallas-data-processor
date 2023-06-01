using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CityOfDallasDataApp.Read;

public class ApiDataReader : IDataReader
{
    private readonly string uri;
    private readonly HttpClient httpClient;
    
    public ApiDataReader(string baseUrl, string uri)
    {
        this.uri = uri;
        this.httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
    }
    public async Task<IEnumerable<T>> ReadData<T>()
    {
        try
        {
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Enumerable.Empty<T>();
        }
    }
}