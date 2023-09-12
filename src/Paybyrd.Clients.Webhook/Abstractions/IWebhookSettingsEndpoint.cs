namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookSettingsEndpoint
{
    ValueTask<IWebhookSettings> CreateAsync(
        ICreateWebhookSettings createWebhookSettings,
        CancellationToken cancellationToken = default);
    
    ValueTask<IWebhookSettingsCollection> QueryAsync(
        IQueryWebhookSettings queryWebhookSettings,
        CancellationToken cancellationToken = default);
}
