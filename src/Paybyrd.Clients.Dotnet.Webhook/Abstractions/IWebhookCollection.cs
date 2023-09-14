namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IWebhookCollection : IReadOnlyCollection<IWebhook>, IPaginationInfo
{
}
