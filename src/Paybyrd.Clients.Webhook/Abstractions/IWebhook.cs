namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhook
{
    /// <summary>
    ///     The date and time the webhook was created.
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    ///     The event that triggered the webhook.
    /// </summary>
    string Event { get; }

    /// <summary>
    ///     The ID of the webhook.
    /// </summary>
    string Id { get; }

    /// <summary>
    ///     The payment method that triggered the webhook.
    /// </summary>
    string PaymentMethod { get; }

    /// <summary>
    ///     The reference IDs of the webhook.
    /// </summary>
    string[] ReferenceIds { get; }

    /// <summary>
    ///     The date and time the webhook was sent.
    /// </summary>
    DateTime? SentAt { get; }

    /// <summary>
    ///     The ID of the webhook settings.
    /// </summary>
    string SettingsId { get; }
}
