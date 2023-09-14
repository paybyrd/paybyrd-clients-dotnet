namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IWebhookClient
{
    IWebhooksEndpoint Webhooks { get; }
    IWebhookSettingsEndpoint WebhookSettings { get; }
}
