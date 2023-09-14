using Paybyrd.Clients.Dotnet.Webhook.Abstractions;

namespace Paybyrd.Clients.Dotnet.Webhook.Contracts;

internal class WebhookSettingsCollection : List<IWebhookSettings>, IWebhookSettingsCollection
{
    public WebhookSettingsCollection(IEnumerable<WebhookSettings> settings) : base(settings)
    {
    }
}
