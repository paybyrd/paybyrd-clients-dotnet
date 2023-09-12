namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IAuthorizationHandler
{
    ValueTask<IAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken);
}
