namespace Relx.Api.AcceptanceTests;

public class Utils
{
    public static StringContent GenerateHttpRequestBody(object requestBody)
    {
        var serialisedBody = JsonConvert.SerializeObject(
                                    requestBody,
                                    new JsonSerializerSettings
                                    {
                                        NullValueHandling = NullValueHandling.Ignore,
                                        Formatting = Formatting.Indented
                                    });
        return new StringContent(serialisedBody, Encoding.UTF8, "application/json");
    }
}
