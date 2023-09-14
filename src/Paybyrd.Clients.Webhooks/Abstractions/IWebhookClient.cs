namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IWebhookClient
{
    IWebhooksEndpoint Webhooks { get; }
    IWebhookSettingsEndpoint WebhookSettings { get; }
}
