using System.Text;
using System.Text.Json;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Contracts;
using Paybyrd.Clients.Webhook.Utils;

namespace Paybyrd.Clients.Webhook.Endpoints;

internal class WebhooksEndpoint : IWebhooksEndpoint
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAuthorization _authorization;

    public WebhooksEndpoint(
        IHttpClientFactory httpClientFactory,
        IAuthorization authorization)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
    }

    public async ValueTask ResendAsync(IResendWebhooks resendWebhook, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/settings/resend");
        request.Headers.Add("x-api-key", _authorization.ApiKey);
        
        var content = new StringContent(JsonSerializer.Serialize(resendWebhook), Encoding.UTF8, "application/json");
        request.Content = content;

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async ValueTask<IWebhookCollection> QueryAsync(IQueryWebhooks queryWebhooks, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/webhooks");
        request.Headers.Add("x-api-key", _authorization.ApiKey);

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var webhooks = JsonSerializer.Deserialize<Contracts.Webhook[]>(json);
        return new WebhookCollection(webhooks!);
    }

    public async ValueTask<IWebhookAttemptCollection> QueryAsync(IQueryWebhookAttempts queryWebhookAttempts,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/webhooks");
        request.Headers.Add("x-api-key", _authorization.ApiKey);

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var attempts = JsonSerializer.Deserialize<WebhookAttempt[]>(json);
        return new WebhookAttemptCollection(attempts!);
    }
}
