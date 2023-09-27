using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookCollection : List<IWebhook>, IWebhookCollection
{
    private readonly IPaginationInfo _paginationInfo;

    public WebhookCollection(IPaginationInfo paginationInfo, IEnumerable<Webhook> webhooks) : base(webhooks)
    {
        _paginationInfo = paginationInfo;
    }

    public int CurrentPage => _paginationInfo.CurrentPage;
    public int PageSize => _paginationInfo.PageSize;
    public int TotalItems => _paginationInfo.TotalItems;
    public int TotalPages => _paginationInfo.TotalPages;
}
