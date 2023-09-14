namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IQueryWebhookSettings
{
    IEnumerable<long> StoreIds { get; }
}
