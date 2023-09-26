using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class PaginationInfo : IPaginationInfo
{
    public PaginationInfo(HttpResponseMessage responseMessage)
    {
        CurrentPage = GetIntValue(responseMessage, "x-current-page");
        PageSize = GetIntValue(responseMessage, "x-page-size");
        TotalPages = GetIntValue(responseMessage, "x-page-count");
        TotalItems = GetIntValue(responseMessage, "x-total-item-count");
    }

    public int CurrentPage { get; }
    public int PageSize { get; }
    public int TotalItems { get; }
    public int TotalPages { get; }

    private static int GetIntValue(HttpResponseMessage responseMessage, string key)
    {
        if (responseMessage.Headers.TryGetValues(key, out var values)
            && int.TryParse(values.FirstOrDefault(), out var value))
        {
            return value;
        }

        return 0;
    }
}
