using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class Webhook : IWebhook
{
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("paymentMethod")]
    public string PaymentMethod { get; set; } = string.Empty;

    [JsonPropertyName("referenceIds")]
    public string[] ReferenceIds { get; set; } = Array.Empty<string>();

    [JsonPropertyName("sentAt")]
    public DateTime? SentAt { get; set; }

    [JsonPropertyName("settingsId")]
    public string SettingsId { get; set; } = string.Empty;
}
