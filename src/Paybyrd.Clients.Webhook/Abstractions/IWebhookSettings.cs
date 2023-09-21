using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookSettings
{
    IWebhookCredential Credential { get; }
    Event[] Events { get; }
    string Id { get; }
    PaymentMethod[] PaymentMethods { get; }
    string Url { get; }
}
