using System.Text;
using System.Text.Json;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Contracts;
using Paybyrd.Clients.Webhook.Utils;

namespace Paybyrd.Clients.Webhook.Endpoints;

internal class WebhooksEndpoint : IWebhooksEndpoint
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IWebhookAuthorizationHandler _webhookAuthorizationHandler;

    public WebhooksEndpoint(
        IHttpClientFactory httpClientFactory,
        IWebhookAuthorizationHandler webhookAuthorizationHandler)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _webhookAuthorizationHandler = webhookAuthorizationHandler ?? throw new ArgumentNullException(nameof(webhookAuthorizationHandler));
    }

    public async ValueTask<IWebhookCollection> QueryAsync(IQueryWebhooks queryWebhooks, CancellationToken cancellationToken = default)
    {
        var authorization = await _webhookAuthorizationHandler.GetAuthorizationAsync(cancellationToken);

        var queryParametersBuilder = new QueryParametersBuilder()
            .Add("referenceId", queryWebhooks.ReferenceId)
            .Add("storeIds", queryWebhooks.StoreIds?.Select(x => x.ToString()).ToArray() ?? Array.Empty<string>());

        var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/webhooks{queryParametersBuilder.Build()}");
        request.Headers.Add(authorization.Key, authorization.Value);
        request.Headers.Add("x-page", queryWebhooks.Page.ToString());
        request.Headers.Add("x-page-size", queryWebhooks.PageSize.ToString());

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var dataResponse = JsonSerializer.Deserialize<WrappedResponse<Contracts.Webhook[]>>(json);
        return new WebhookCollection(new PaginationInfo(response), dataResponse!.Data);
    }

    public async ValueTask<IWebhookAttemptCollection> QueryAsync(IQueryWebhookAttempts queryWebhookAttempts,
        CancellationToken cancellationToken = default)
    {
        var authorization = await _webhookAuthorizationHandler.GetAuthorizationAsync(cancellationToken);

        var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/webhooks/{queryWebhookAttempts.WebhookId}/attempts");
        request.Headers.Add(authorization.Key, authorization.Value);
        request.Headers.Add("x-page", queryWebhookAttempts.Page.ToString());
        request.Headers.Add("x-page-size", queryWebhookAttempts.PageSize.ToString());

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var dataResponse = JsonSerializer.Deserialize<WrappedResponse<WebhookAttempt[]>>(json);
        return new WebhookAttemptCollection(new PaginationInfo(response), dataResponse!.Data);
    }

    public async ValueTask ResendAsync(IResendWebhooks resendWebhook, CancellationToken cancellationToken = default)
    {
        var authorization = await _webhookAuthorizationHandler.GetAuthorizationAsync(cancellationToken);

        var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/webhooks/resend");
        request.Headers.Add(authorization.Key, authorization.Value);

        var content = new StringContent(JsonSerializer.Serialize(resendWebhook), Encoding.UTF8, "application/json");
        request.Content = content;

        using var client = _httpClientFactory.CreateClient(Constants.HTTP_CLIENT_KEY);
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
