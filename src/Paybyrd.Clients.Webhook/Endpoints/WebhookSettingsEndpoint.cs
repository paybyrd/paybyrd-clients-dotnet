using System.Text;
using System.Text.Json;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Contracts;
using Paybyrd.Clients.Webhook.Utils;

namespace Paybyrd.Clients.Webhook.Endpoints;

internal class WebhookSettingsEndpoint : IWebhookSettingsEndpoint
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IWebhookAuthorizationHandler _webhookAuthorizationHandler;

    public WebhookSettingsEndpoint(
        IHttpClientFactory httpClientFactory,
        IWebhookAuthorizationHandler webhookAuthorizationHandler)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _webhookAuthorizationHandler = webhookAuthorizationHandler ?? throw new ArgumentNullException(nameof(webhookAuthorizationHandler));
    }

    public async ValueTask<IWebhookSettings> CreateAsync(ICreateWebhookSettings createWebhookSettings,
        CancellationToken cancellationToken = default)
    {
        var authorization = await _webhookAuthorizationHandler.GetAuthorizationAsync(cancellationToken);

        var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/settings");
        request.Headers.Add(authorization.Key, authorization.Value);

        var content = new StringContent(JsonSerializer.Serialize(new CreateWebhookSettingsRequest(createWebhookSettings)), Encoding.UTF8, "application/json");
        request.Content = content;

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var dataResponse = JsonSerializer.Deserialize<WrappedResponse<WebhookSettings>>(json);
        return dataResponse!.Data;
    }

    public async ValueTask DeleteAsync(IDeleteWebhookSettings deleteWebhookSettings, CancellationToken cancellationToken = default)
    {
        var authorization = await _webhookAuthorizationHandler.GetAuthorizationAsync(cancellationToken);

        var request = new HttpRequestMessage(HttpMethod.Delete, $"api/v1/settings/{deleteWebhookSettings.SettingsId}");
        request.Headers.Add(authorization.Key, authorization.Value);

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async ValueTask<IWebhookSettingsCollection> QueryAsync(IQueryWebhookSettings queryWebhookSettings, CancellationToken cancellationToken = default)
    {
        var authorization = await _webhookAuthorizationHandler.GetAuthorizationAsync(cancellationToken);

        var queryParametersBuilder = new QueryParametersBuilder();
        queryParametersBuilder.Add("storeIds", queryWebhookSettings.StoreIds.Select(x => x.ToString()).ToArray());

        var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/settings{queryParametersBuilder.Build()}");
        request.Headers.Add(authorization.Key, authorization.Value);

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var dataResponse = JsonSerializer.Deserialize<WrappedResponse<WebhookSettings[]>>(json);
        return new WebhookSettingsCollection(dataResponse!.Data);
    }

    public async ValueTask<IWebhookSettings> QueryByIdAsync(IQueryWebhookSettingsById queryWebhookSettingsById, CancellationToken cancellationToken = default)
    {
        var authorization = await _webhookAuthorizationHandler.GetAuthorizationAsync(cancellationToken);

        var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/settings/{queryWebhookSettingsById.SettingsId}");
        request.Headers.Add(authorization.Key, authorization.Value);

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var dataResponse = JsonSerializer.Deserialize<WrappedResponse<WebhookSettings>>(json);
        return dataResponse!.Data;
    }
}
