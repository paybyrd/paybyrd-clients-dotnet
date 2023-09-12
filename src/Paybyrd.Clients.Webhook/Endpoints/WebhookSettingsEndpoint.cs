using System.Text;
using System.Text.Json;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Contracts;
using Paybyrd.Clients.Webhook.Utils;

namespace Paybyrd.Clients.Webhook.Endpoints;

internal class WebhookSettingsEndpoint : IWebhookSettingsEndpoint
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAuthorizationHandler _authorizationHandler;

    public WebhookSettingsEndpoint(
        IHttpClientFactory httpClientFactory,
        IAuthorizationHandler authorizationHandler)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _authorizationHandler = authorizationHandler ?? throw new ArgumentNullException(nameof(authorizationHandler));
    }

    public async ValueTask<IWebhookSettings> CreateAsync(ICreateWebhookSettings createWebhookSettings,
        CancellationToken cancellationToken = default)
    {
        var authorization = await _authorizationHandler.GetAuthorizationAsync(cancellationToken);

        var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/settings");
        request.Headers.Add(authorization.Key, authorization.Value);

        var content = new StringContent(JsonSerializer.Serialize(createWebhookSettings), Encoding.UTF8, "application/json");
        request.Content = content;

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var dataResponse = JsonSerializer.Deserialize<WrappedResponse<WebhookSettings>>(json);
        return dataResponse!.Data;
    }
    
    public async ValueTask<IWebhookSettingsCollection> QueryAsync(IQueryWebhookSettings queryWebhookSettings, CancellationToken cancellationToken = default)
    {
        var authorization = await _authorizationHandler.GetAuthorizationAsync(cancellationToken);

        var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/settings");
        request.Headers.Add(authorization.Key, authorization.Value);

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var dataResponse = JsonSerializer.Deserialize<WrappedResponse<WebhookSettings[]>>(json);
        return new WebhookSettingsCollection(dataResponse!.Data);
    }
}
