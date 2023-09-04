using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookCollection : List<IWebhook>, IWebhookCollection
{
    public WebhookCollection(IEnumerable<Webhook> webhooks) : base(webhooks)
    {
    }
}
