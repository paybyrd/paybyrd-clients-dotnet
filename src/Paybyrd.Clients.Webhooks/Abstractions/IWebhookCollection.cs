namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IWebhookCollection : IReadOnlyCollection<IWebhook>, IPaginationInfo
{
}
