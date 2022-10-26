namespace Relx.Api.AcceptanceTests.Hooks;

[Binding]
public class Hooks
{
    private static IConfiguration configuration;
    private readonly IObjectContainer _objectContainer;
    private static PetStoreApi petStoreApi;

    public Hooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeTestRun]
    public static void TestRunSetup()
    {
        SetConfiguration();
        SetAppSettingConstants();
    }

    public static void SetConfiguration()
    {
        configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings_test.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();
    }

    private static void SetAppSettingConstants()
    {
        petStoreApi = new PetStoreApi(configuration.GetSection("PetStoreApiUrl").Value.ToString());
    }

    [BeforeScenario]
    public void ScenarioSetup()
    {
        _objectContainer.RegisterInstanceAs(configuration);
        _objectContainer.RegisterInstanceAs(petStoreApi);
    }
}
