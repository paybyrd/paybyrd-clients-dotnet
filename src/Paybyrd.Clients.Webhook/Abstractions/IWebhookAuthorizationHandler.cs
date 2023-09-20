namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAuthorizationHandler
{
    /// <summary>
    ///     Get the authorization for the webhook.
    /// </summary>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     The authorization for the webhook.
    /// </returns>
    ValueTask<IWebhookAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken);
}
