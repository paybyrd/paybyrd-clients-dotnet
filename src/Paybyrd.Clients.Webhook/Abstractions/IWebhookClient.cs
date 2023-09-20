namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookClient
{
    /// <summary>
    /// Webhooks endpoint, where all the webhooks methods are available.
    /// </summary>
    IWebhooksEndpoint Webhooks { get; }
    /// <summary>
    /// Settings endpoint, where all the webhook settings methods are available.
    /// </summary>
    IWebhookSettingsEndpoint WebhookSettings { get; }
}
