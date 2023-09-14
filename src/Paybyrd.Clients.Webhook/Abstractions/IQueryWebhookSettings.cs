namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IQueryWebhookSettings
{
    IEnumerable<long> StoreIds { get; }
}
