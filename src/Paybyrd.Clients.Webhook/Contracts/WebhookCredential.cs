using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookCredential : IWebhookCredential
{
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
