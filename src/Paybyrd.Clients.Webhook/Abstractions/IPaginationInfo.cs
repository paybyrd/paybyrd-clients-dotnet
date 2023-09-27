namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IPaginationInfo
{
    int CurrentPage { get; }
    int PageSize { get; }
    int TotalItems { get; }
    int TotalPages { get; }
}
