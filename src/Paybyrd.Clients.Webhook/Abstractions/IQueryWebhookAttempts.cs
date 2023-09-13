namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IQueryWebhookAttempts
{
    long? Page { get; }
    long? PageSize { get; }
    string WebhookId { get; }
}
