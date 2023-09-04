using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class Webhook : IWebhook
{
    public string Id { get; init; } = string.Empty;
    public string SettingsId { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime? SentAt { get; init; }
    public string Event { get; init; } = string.Empty;
    public string PaymentMethod { get; init; } = string.Empty;
    public string[] ReferenceId { get; } = Array.Empty<string>();
}
