using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttempt
{
    /// <summary>
    /// The ID of the webhook attempt.
    /// </summary>
    string Id { get; }
    /// <summary>
    /// The ID of the webhook.
    /// </summary>
    string WebhookId { get; }
    /// <summary>
    /// The date and time the webhook attempt was created.
    /// </summary>
    DateTime CreatedAt { get; }
    /// <summary>
    /// The event that triggered the webhook.
    /// </summary>
    Event Event { get; }
    /// <summary>
    /// The payment method that triggered the webhook.
    /// </summary>
    PaymentMethod PaymentMethod { get; }
    /// <summary>
    /// The settings of the webhook attempt.
    /// </summary>
    IWebhookAttemptSettings Settings { get; }
    /// <summary>
    /// The payload of the webhook attempt.
    /// </summary>
    object Content { get; }
    /// <summary>
    /// The response of the webhook attempt.
    /// </summary>
    IWebhookAttemptResponse Response { get; }
}
