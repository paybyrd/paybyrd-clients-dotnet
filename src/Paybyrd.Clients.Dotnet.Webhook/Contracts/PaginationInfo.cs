using Paybyrd.Clients.Dotnet.Webhook.Abstractions;

namespace Paybyrd.Clients.Dotnet.Webhook.Contracts;

internal class PaginationInfo : IPaginationInfo
{
    public PaginationInfo(HttpResponseMessage responseMessage)
    {
        CurrentPage = GetLongValue(responseMessage, "x-current-page");
        PageSize = GetLongValue(responseMessage, "x-page-size");
        TotalPages = GetLongValue(responseMessage, "x-page-count");
        TotalItems = GetLongValue(responseMessage, "x-total-items");
    }

    public long CurrentPage { get; }
    public long PageSize { get; }
    public long TotalPages { get; }
    public long TotalItems { get; }
    
    private static long GetLongValue(HttpResponseMessage responseMessage, string key)
    {
        if (responseMessage.Headers.TryGetValues(key, out var values)
            && long.TryParse(values.FirstOrDefault(), out var value))
        {
            return value;
        }

        return 0;
    }
}
