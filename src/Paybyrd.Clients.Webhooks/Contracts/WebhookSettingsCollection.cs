using Paybyrd.Clients.Webhooks.Abstractions;

namespace Paybyrd.Clients.Webhooks.Contracts;

internal class WebhookSettingsCollection : List<IWebhookSettings>, IWebhookSettingsCollection
{
    public WebhookSettingsCollection(IEnumerable<WebhookSettings> settings) : base(settings)
    {
    }
}
