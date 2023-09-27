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
        var options = builder.Build();
        services.Configure<WebhookApiOptions>(opt => opt.Update(options));

        var httpClientBuilder = services.AddHttpClient(Constants.HTTP_CLIENT_KEY, client =>
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                client.Timeout = options.Timeout;
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(i)));

        if (options.HttpHandlerType is not null)
        {
            httpClientBuilder.AddHttpMessageHandler(sp => (DelegatingHandler)sp.GetRequiredService(options.HttpHandlerType));
        }

        services.AddScoped<IWebhookClient, WebhookClient>();
        services.AddScoped<IWebhooksEndpoint, WebhooksEndpoint>();
        services.AddScoped<IWebhookSettingsEndpoint, WebhookSettingsEndpoint>();
        services.AddScoped<IWebhookAuthorizationHandler, TAuthorizationHandler>();

        return services;
    }
}
