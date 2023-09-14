using Paybyrd.Clients.Dotnet.Webhook.Abstractions;

namespace Paybyrd.Clients.Dotnet.Webhook.Contracts;

internal class WebhookAttemptCollection : List<IWebhookAttempt>, IWebhookAttemptCollection
{
    private readonly IPaginationInfo _paginationInfo;

    public WebhookAttemptCollection(IPaginationInfo paginationInfo, IEnumerable<WebhookAttempt> attempts) : base(attempts)
    {
        _paginationInfo = paginationInfo ?? throw new ArgumentNullException(nameof(paginationInfo));
    }

    public long CurrentPage => _paginationInfo.CurrentPage;
    public long PageSize => _paginationInfo.PageSize;
    public long TotalPages => _paginationInfo.TotalPages;
    public long TotalItems => _paginationInfo.TotalItems;
}
