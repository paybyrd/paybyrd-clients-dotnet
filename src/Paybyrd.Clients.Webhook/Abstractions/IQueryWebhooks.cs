namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IQueryWebhooks
{
    /// <summary>
    /// The current page.
    /// </summary>
    long? Page { get; }
    /// <summary>
    /// The page size.
    /// </summary>
    long? PageSize { get; }
    /// <summary>
    /// The store IDs to query webhooks for.
    /// </summary>
    IEnumerable<long> StoreIds { get; }
    /// <summary>
    /// The reference ID to query webhooks for.
    /// </summary>
    /// <remarks>
    /// It can be the transaction, order or chargeback ID.
    /// </remarks>
    string? ReferenceId { get; }
}
