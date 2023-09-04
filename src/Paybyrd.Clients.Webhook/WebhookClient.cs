using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Endpoints;

namespace Paybyrd.Clients.Webhook;

internal sealed class WebhookClient : IWebhookClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WebhookClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public IWebhooksEndpoint Webhooks(IAuthorization authorization)
    {
        return new WebhooksEndpoint(_httpClientFactory, authorization);
    }

    public ISettingsEndpoint Settings(IAuthorization authorization)
    {
        return new WebhookSettingsEndpoint(_httpClientFactory, authorization);
    }
}
