﻿using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook;

internal sealed class WebhookClient : IWebhookClient
{
    public WebhookClient(IWebhooksEndpoint webhooksEndpoint, IWebhookSettingsEndpoint webhookSettingsEndpoint)
    {
        Webhooks = webhooksEndpoint ?? throw new ArgumentNullException(nameof(webhooksEndpoint));
        WebhookSettings = webhookSettingsEndpoint ?? throw new ArgumentNullException(nameof(webhookSettingsEndpoint));
    }

    public IWebhooksEndpoint Webhooks { get; }
    public IWebhookSettingsEndpoint WebhookSettings { get; }
}
