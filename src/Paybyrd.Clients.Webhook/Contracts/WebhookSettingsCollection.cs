using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookSettingsCollection : List<IWebhookSettings>, IWebhookSettingsCollection
{
    public WebhookSettingsCollection(IEnumerable<WebhookSettings> settings) : base(settings)
    {
    }
}
