namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IWebhookAttemptCollection : IReadOnlyCollection<IWebhookAttempt>, IPaginationInfo
{
}
