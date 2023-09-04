using System.Net;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttemptResponse : IWebhookAttemptResponse
{
    public HttpStatusCode StatusCode { get; init; }
    public string? Content { get; init; }
}
