using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Extensions;
using Paybyrd.Clients.Webhook.Tests.Utils;

namespace Paybyrd.Clients.Webhook.Tests.Fixtures;

public class ServiceProviderFixture
{
    private readonly IServiceCollection _services;

    public ServiceProviderFixture()
    {
        _services = new ServiceCollection();
        _services.AddWebhookClient<WebhookAuthorizationHandler>(builder =>
        {
            builder
                .WithSandboxBaseUrl()
                .WithTimeout(TimeSpan.FromSeconds(10));
        });
    }

    public ServiceProvider BuildServiceProvider()
    {
        return _services.BuildServiceProvider();
    }

    private class WebhookAuthorization : IWebhookAuthorization
    {
        public string Key { get; } = "x-api-key";
        public string Value { get; } = Configuration.Self.GetValue<string>("Webhook:ApiKey")!;
    }

    private class WebhookAuthorizationHandler : IWebhookAuthorizationHandler
    {
        public ValueTask<IWebhookAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken)
        {
            return new ValueTask<IWebhookAuthorization>(new WebhookAuthorization());
        }
    }
}
