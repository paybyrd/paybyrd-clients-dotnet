using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookCredential : IWebhookCredential
{
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("type")]
    [JsonConverter(typeof(CredentialType.Converter))]
    public CredentialType Type { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
