namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IWebhookAttemptCollection : IReadOnlyCollection<IWebhookAttempt>, IPaginationInfo
{
}
