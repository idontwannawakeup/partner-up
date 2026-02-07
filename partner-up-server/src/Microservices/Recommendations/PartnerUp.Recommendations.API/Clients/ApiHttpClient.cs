using System.Text.Json;

namespace PartnerUp.Recommendations.API.Clients;

public class ApiHttpClient
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public HttpClient Client { get; }
    
    public ApiHttpClient(HttpClient client)
    {
        Client = client;
    }
    
    public async Task<T> GetAsync<T>(string requestUri)
    {
        var response = await Client.GetAsync(requestUri);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseBody, Options)!;
    }
    
    public async Task PostAsync(string requestUri)
    {
        await Client.PostAsync(requestUri, null);
    }
}
