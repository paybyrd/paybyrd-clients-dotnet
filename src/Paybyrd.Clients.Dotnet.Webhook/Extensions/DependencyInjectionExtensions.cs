using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Paybyrd.Clients.Dotnet.Webhook.Abstractions;
using Paybyrd.Clients.Dotnet.Webhook.Endpoints;
using Paybyrd.Clients.Dotnet.Webhook.Options;
using Paybyrd.Clients.Dotnet.Webhook.Utils;
using Polly;

namespace Paybyrd.Clients.Dotnet.Webhook.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddWebhookClient<TAuthorizationHandler>(
        this IServiceCollection services,
        Action<WebhookApiOptions> optionsBuild)
        where TAuthorizationHandler : class, IWebhookAuthorizationHandler
    {
        services.Configure(optionsBuild);
        
        services.AddHttpClient(Constants.HTTP_CLIENT_KEY, (sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<WebhookApiOptions>>().Value;
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
