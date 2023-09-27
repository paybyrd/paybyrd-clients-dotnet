using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttemptSettings : IWebhookAttemptSettings
{
    [JsonPropertyName("credential")]
    [JsonConverter(typeof(IWebhookCredential.Converter))]
    public IWebhookCredential Credential { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
