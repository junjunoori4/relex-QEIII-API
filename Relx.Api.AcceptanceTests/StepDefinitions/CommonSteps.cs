using Relx.Api.AcceptanceTests.Model;

namespace Relx.Api.AcceptanceTests.StepDefinitions;

[Binding]
public class CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly PetStoreApi _petStoreApi;
    private FindByStatusRequest findByStatusRequest;
    private readonly Dictionary<string, string> _queryParameters = new Dictionary<string, string>();

    public CommonSteps(ScenarioContext scenarioContext, PetStoreApi petStoreApi)
    {
        _scenarioContext = scenarioContext;
        _petStoreApi = petStoreApi;
    }

    [Given(@"I have '([^']*)' status")]
    public void GivenIHaveStatus(string status)
    {
        findByStatusRequest.Status[1] = status;
    }

    [When(@"I call the '([^']*)' endpoint")]
    public async Task WhenICallTheEndpoint(string endPoint)
    {
        //Below statement is to get the request body and pass it to an object body
        _scenarioContext.TryGetValue(ScenarioContextKeys.RequestBody, out object body);

        /*Using switch statement to call the respective endpoint method declared
   in ToDoApi class by sending the request*/

        var resposne = endPoint switch
        {
            "/pet/findByStatus" => await _petStoreApi.GetFindByStatusApiResponseAsync(_queryParameters),
        };

        if (_scenarioContext.ContainsKey(ScenarioContextKeys.ApiResponse))
        {
            _scenarioContext.Remove(ScenarioContextKeys.ApiResponse);
        }

        //This statement is to store the response received above
        _scenarioContext.Add(ScenarioContextKeys.ApiResponse, resposne);
    }

    [Given(@"I have a request with '([^']*)' as '([^']*)'")]
    public void GivenIHaveARequestWithAs(string parameter, string paramenterValue)
    {
        _queryParameters.Add(parameter, paramenterValue);        
    }

    [Then(@"I get '([^']*)' status code")]
    public void ThenIGetStatusCode(int statusCode)
    {
        var response = _scenarioContext.Get<HttpResponseMessage>(ScenarioContextKeys.ApiResponse);
        Assert.That((int)response.StatusCode, Is.EqualTo(statusCode));
    }

}
