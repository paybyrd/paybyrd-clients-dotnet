using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttempt : IWebhookAttempt
{
    public string Id { get; init; } = string.Empty;
    public string AttemptId { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public string Event { get; init; } = string.Empty;
    public string PaymentMethod { get; init; } = string.Empty;
    public IWebhookAttemptSettings Settings { get; init; } = null!;
    public object Content { get; init; } = null!;
    public IWebhookAttemptResponse Response { get; init; } = null!;
}
