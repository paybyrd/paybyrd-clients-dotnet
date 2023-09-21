using Microsoft.Extensions.DependencyInjection;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Endpoints;
using Paybyrd.Clients.Webhook.Options;
using Paybyrd.Clients.Webhook.Utils;
using Polly;

namespace Paybyrd.Clients.Webhook.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddWebhookClient<TAuthorizationHandler>(
        this IServiceCollection services,
        Action<WebhookApiOptionsBuilder> optionsBuild)
        where TAuthorizationHandler : class, IWebhookAuthorizationHandler
    {
        var builder = new WebhookApiOptionsBuilder();
        optionsBuild.Invoke(builder);
        services.Configure<WebhookApiOptions>(options => options.Update(builder.Build()));

        services.AddHttpClient(Constants.HTTP_CLIENT_KEY, (sp, client) =>
            {
                var options = builder.Build();
                client.BaseAddress = new Uri(options.BaseUrl);
                client.Timeout = options.Timeout;
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(i)));

        services.AddScoped<IWebhookClient, WebhookClient>();
        services.AddScoped<IWebhooksEndpoint, WebhooksEndpoint>();
        services.AddScoped<IWebhookSettingsEndpoint, WebhookSettingsEndpoint>();
        services.AddScoped<IWebhookAuthorizationHandler, TAuthorizationHandler>();

        return services;
    }
}
