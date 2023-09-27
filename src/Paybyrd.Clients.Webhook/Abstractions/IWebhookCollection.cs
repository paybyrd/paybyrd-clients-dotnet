namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookCollection : IReadOnlyCollection<IWebhook>, IPaginationInfo
{
}
