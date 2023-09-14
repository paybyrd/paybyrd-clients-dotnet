namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAuthorizationHandler
{
    ValueTask<IWebhookAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken);
}
