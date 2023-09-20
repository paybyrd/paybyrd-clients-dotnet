namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookSettingsEndpoint
{
    /// <summary>
    /// Create a settings to send hooks to a specific URL.
    /// </summary>
    /// <param name="createWebhookSettings">
    /// The settings to create.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// The created settings.
    /// </returns>
    ValueTask<IWebhookSettings> CreateAsync(
        ICreateWebhookSettings createWebhookSettings,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Delete a settings.
    /// </summary>
    /// <param name="deleteWebhookSettings">
    /// The delete requirements to delete.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    ValueTask DeleteAsync(
        IDeleteWebhookSettings deleteWebhookSettings,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Query settings.
    /// </summary>
    /// <param name="queryWebhookSettings">
    /// The query parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// The settings collection according to the parameters.
    /// </returns>
    ValueTask<IWebhookSettingsCollection> QueryAsync(
        IQueryWebhookSettings queryWebhookSettings,
        CancellationToken cancellationToken = default);
}
