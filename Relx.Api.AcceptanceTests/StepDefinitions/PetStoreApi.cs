namespace Relx.Api.AcceptanceTests.StepDefinitions;

public class PetStoreApi
{
    private readonly HttpClient _httpClient;
    public readonly string findByStatusEndpoint = "/v2/pet/findByStatus";

    public PetStoreApi(string host)
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(host) };
        _httpClient.DefaultRequestHeaders.ConnectionClose = true;
    }

    public async Task<HttpResponseMessage> GetFindByStatusApiResponseAsync(Dictionary<string, string> queryParameters)
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_httpClient.BaseAddress, QueryHelpers.AddQueryString(findByStatusEndpoint, queryParameters)),
        };

        var response = await _httpClient.SendAsync(request);
        return response;
    }
}
