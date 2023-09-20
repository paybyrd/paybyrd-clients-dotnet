namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhooksEndpoint
{
    /// <summary>
    /// Resend webhooks.
    /// </summary>
    /// <param name="resendWebhook">
    /// The parameters required to resend webhooks.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    ValueTask ResendAsync(
        IResendWebhooks resendWebhook,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Query webhooks.
    /// </summary>
    /// <param name="queryWebhooks">
    /// The query parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// The webhooks collection according to the parameters.
    /// </returns>
    ValueTask<IWebhookCollection> QueryAsync(
        IQueryWebhooks queryWebhooks,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Query webhook attempts.
    /// </summary>
    /// <param name="queryWebhookAttempts">
    /// The query parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// The webhook attempts collection according to the parameters.
    /// </returns>
    ValueTask<IWebhookAttemptCollection> QueryAsync(
        IQueryWebhookAttempts queryWebhookAttempts,
        CancellationToken cancellationToken = default);

}
