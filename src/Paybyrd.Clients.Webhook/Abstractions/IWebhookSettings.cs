namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookSettings
{
    IWebhookCredential Credential { get; }
    string[] Events { get; }
    string Id { get; }
    string[] PaymentMethods { get; }
    string Url { get; }
}
