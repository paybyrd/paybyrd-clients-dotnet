namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IWebhookAuthorizationHandler
{
    ValueTask<IWebhookAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken);
}
