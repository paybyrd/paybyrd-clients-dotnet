namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IWebhookAuthorizationHandler
{
    ValueTask<IWebhookAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken);
}
