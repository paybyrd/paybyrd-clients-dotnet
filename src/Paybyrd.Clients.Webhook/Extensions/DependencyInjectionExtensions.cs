﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Contracts;
using Paybyrd.Clients.Webhook.Endpoints;
using Paybyrd.Clients.Webhook.Options;
using Paybyrd.Clients.Webhook.Utils;
using Polly;

namespace Paybyrd.Clients.Webhook.Extensions;

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
        
        services.AddSingleton<IWebhookClient, WebhookClient>();
        services.AddSingleton<IWebhooksEndpoint, WebhooksEndpoint>();
        services.AddSingleton<IWebhookSettingsEndpoint, WebhookSettingsEndpoint>();
        services.AddSingleton<IWebhookAuthorizationHandler, TAuthorizationHandler>(); 
            
        return services;
    }
}
