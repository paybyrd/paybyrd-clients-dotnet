using Microsoft.Extensions.Configuration;

namespace Paybyrd.Clients.Dotnet.Webhook.Tests.Utils;

internal static class Configuration
{
    public static IConfiguration Self { get; } = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
}
