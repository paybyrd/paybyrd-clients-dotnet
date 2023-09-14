using System.Net;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttemptResponse : IWebhookAttemptResponse
{
    [JsonPropertyName("statusCode")]
    public HttpStatusCode StatusCode { get; set; }
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}
