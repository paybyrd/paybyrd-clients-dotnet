using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttempt : IWebhookAttempt
{
    public string Id { get; set; } = string.Empty;
    public string AttemptId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Event { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public IWebhookAttemptSettings Settings { get; set; } = null!;
    public object Content { get; set; } = null!;
    public IWebhookAttemptResponse Response { get; set; } = null!;
}
