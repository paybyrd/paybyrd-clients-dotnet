namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IQueryWebhookSettings
{
    IEnumerable<long> StoreIds { get; }
}
