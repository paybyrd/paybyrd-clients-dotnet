namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IQueryWebhookAttempts
{
    long? Page { get; }
    long? PageSize { get; }
    string WebhookId { get; }
}
