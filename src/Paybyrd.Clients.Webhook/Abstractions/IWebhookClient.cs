namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookClient
{
    IWebhooksEndpoint Webhooks(IAuthorization authorization);
    ISettingsEndpoint Settings(IAuthorization authorization);
}

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

public interface ISettingsEndpoint
{
    ValueTask<IWebhookSettings> CreateAsync(
        ICreateWebhookSettings createWebhookSettings,
        CancellationToken cancellationToken = default);
    
    ValueTask<IWebhookSettingsCollection> QueryAsync(
        IQueryWebhookSettings queryWebhookSettings,
        CancellationToken cancellationToken = default);
}
