using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookSettings : IWebhookSettings
{
    [JsonPropertyName("credential")]
    [JsonConverter(typeof(IWebhookCredential.Converter))]
    public IWebhookCredential Credential { get; set; } = null!;

    [JsonPropertyName("events")]
    public string[] Events { get; set; } = Array.Empty<string>();

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("paymentMethods")]
    public string[] PaymentMethods { get; set; } = Array.Empty<string>();

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
