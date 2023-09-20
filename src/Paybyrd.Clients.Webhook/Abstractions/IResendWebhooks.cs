namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IResendWebhooks
{
    /// <summary>
    /// The IDs of the webhooks to resend.
    /// </summary>
    string[] Ids { get; }
    /// <summary>
    /// The URL to resend the webhooks to.
    /// </summary>
    string? Url { get; }
}
