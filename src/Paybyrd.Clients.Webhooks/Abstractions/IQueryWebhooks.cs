namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IQueryWebhooks
{
    long? Page { get; }
    long? PageSize { get; }
    IEnumerable<long> StoreIds { get; }
    string? ReferenceId { get; }
}
