namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhooksEndpoint
{
    ValueTask ResendAsync(
        IResendWebhooks resendWebhook,
        CancellationToken cancellationToken = default);
    
    ValueTask<IWebhookCollection> QueryAsync(
        IQueryWebhooks queryWebhooks,
        CancellationToken cancellationToken = default);

    ValueTask<IWebhookAttemptCollection> QueryAsync(
        IQueryWebhookAttempts queryWebhookAttempts,
        CancellationToken cancellationToken = default);

}
