namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IPaginationInfo
{
    long CurrentPage { get; }
    long PageSize { get; }
    long TotalPages { get; }
    long TotalItems { get; }
}
