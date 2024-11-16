namespace PartnerUp.Recommendations.API.Common;

public class IdentityPeopleHttpClient
{
    public IdentityPeopleHttpClient(HttpClient client)
    {
        Client = client;
    }

    public HttpClient Client { get; }
}
