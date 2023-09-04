using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Contracts;
using Paybyrd.Clients.Webhook.Utils;

namespace Paybyrd.Clients.Webhook.Endpoints;

internal class WebhookSettingsEndpoint : ISettingsEndpoint
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAuthorization _authorization;

    public WebhookSettingsEndpoint(
        IHttpClientFactory httpClientFactory,
        IAuthorization authorization)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
    }

    public async ValueTask<IWebhookSettings> CreateAsync(ICreateWebhookSettings createWebhookSettings,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/settings");
        request.Headers.Add("x-api-key", _authorization.ApiKey);
        
        var content = new StringContent(JsonSerializer.Serialize(createWebhookSettings), Encoding.UTF8, MediaTypeNames.Application.Json);
        request.Content = content;

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var webhookSettings = await response.Content.ReadFromJsonAsync<WebhookSettings>(cancellationToken: cancellationToken);
        
        return webhookSettings!;

    }
    
    public async ValueTask<IWebhookSettingsCollection> QueryAsync(IQueryWebhookSettings queryWebhookSettings, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/settings");
        request.Headers.Add("x-api-key", _authorization.ApiKey);

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var webhookSettings = await response.Content.ReadFromJsonAsync<WebhookSettings[]>(cancellationToken: cancellationToken);
        return new WebhookSettingsCollection(webhookSettings!);
    }
}
