namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookClient
{
    IWebhooksEndpoint Webhooks { get; }
    IWebhookSettingsEndpoint WebhookSettings { get; }
}
