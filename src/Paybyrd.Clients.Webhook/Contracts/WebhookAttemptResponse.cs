using System.Net;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttemptResponse : IWebhookAttemptResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string? Content { get; set; }
}
