namespace PartnerUp.Recommendations.API.Common;

public class WorkManagementHttpClient
{
    public WorkManagementHttpClient(HttpClient client)
    {
        Client = client;
    }

    public HttpClient Client { get; }
}
