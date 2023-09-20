namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IQueryWebhookSettings
{
    /// <summary>
    /// The store IDs to query webhook settings for.
    /// </summary>
    IEnumerable<long> StoreIds { get; }
}
