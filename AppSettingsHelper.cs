using Microsoft.Extensions.Configuration;

namespace AskApp;

public static class AppSettingsReader
{
    public static IConfiguration GetConfiguation()
    {
        var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        return configurationRoot;
    }
}