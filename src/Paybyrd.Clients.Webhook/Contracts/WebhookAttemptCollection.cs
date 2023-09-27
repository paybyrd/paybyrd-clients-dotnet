using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttemptCollection : List<IWebhookAttempt>, IWebhookAttemptCollection
{
    private readonly IPaginationInfo _paginationInfo;

    public WebhookAttemptCollection(IPaginationInfo paginationInfo, IEnumerable<WebhookAttempt> attempts) : base(attempts)
    {
        _paginationInfo = paginationInfo ?? throw new ArgumentNullException(nameof(paginationInfo));
    }

    public int CurrentPage => _paginationInfo.CurrentPage;
    public int PageSize => _paginationInfo.PageSize;
    public int TotalItems => _paginationInfo.TotalItems;
    public int TotalPages => _paginationInfo.TotalPages;
}
