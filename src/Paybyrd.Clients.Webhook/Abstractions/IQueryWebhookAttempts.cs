namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IQueryWebhookAttempts
{
    /// <summary>
    /// The current page.
    /// </summary>
    long? Page { get; }
    
    /// <summary>
    /// The page size.
    /// </summary>
    long? PageSize { get; }
    
    /// <summary>
    /// The ID of the webhook to query attempts for.
    /// </summary>
    string WebhookId { get; }
}
