using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttemptCollection : List<IWebhookAttempt>, IWebhookAttemptCollection
{
    public WebhookAttemptCollection(IEnumerable<WebhookAttempt> attempts) : base(attempts)
    {
    }
}
