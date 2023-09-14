namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IQueryWebhookAttempts
{
    long? Page { get; }
    long? PageSize { get; }
    string WebhookId { get; }
}
