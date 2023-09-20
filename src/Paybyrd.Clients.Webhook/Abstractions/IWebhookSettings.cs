using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookSettings
{
    string Id { get; }
    string Url { get; }
    string Username { get; }
    string Password { get; }
    Event[] Events { get; }
    PaymentMethod[] PaymentMethods { get; }
}
