namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttempt
{
    string Id { get; }
    string AttemptId { get; }
    DateTime CreatedAt { get; }
    string Event { get; }
    string PaymentMethod { get; }
    IWebhookAttemptSettings Settings { get; }
    object Content { get; }
    IWebhookAttemptResponse Response { get; }
}
