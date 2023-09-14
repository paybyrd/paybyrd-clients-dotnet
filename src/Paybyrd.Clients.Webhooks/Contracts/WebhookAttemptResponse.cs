using System.Net;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhooks.Abstractions;

namespace Paybyrd.Clients.Webhooks.Contracts;

internal class WebhookAttemptResponse : IWebhookAttemptResponse
{
    [JsonPropertyName("statusCode")]
    public HttpStatusCode StatusCode { get; set; }
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}
