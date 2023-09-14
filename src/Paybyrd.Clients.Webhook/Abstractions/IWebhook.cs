namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhook
{
    string Id { get; }
    string SettingsId { get; }
    DateTime CreatedAt { get; }
    DateTime? SentAt { get; }
    string Event { get; }
    string PaymentMethod { get; }
    string[] ReferenceIds { get; }
}
