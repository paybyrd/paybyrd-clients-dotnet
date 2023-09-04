using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class Webhook : IWebhook
{
    public string Id { get; set; } = string.Empty;
    public string SettingsId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public string Event { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public string[] ReferenceId { get; set; } = Array.Empty<string>();
}
