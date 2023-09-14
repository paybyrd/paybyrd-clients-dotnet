using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookCollection : List<IWebhook>, IWebhookCollection
{
    private readonly IPaginationInfo _paginationInfo;

    public WebhookCollection(IPaginationInfo paginationInfo, IEnumerable<Webhook> webhooks) : base(webhooks)
    {
        _paginationInfo = paginationInfo;
    }

    public long CurrentPage => _paginationInfo.CurrentPage;
    public long PageSize => _paginationInfo.PageSize;
    public long TotalPages => _paginationInfo.TotalPages;
    public long TotalItems => _paginationInfo.TotalItems;
}
