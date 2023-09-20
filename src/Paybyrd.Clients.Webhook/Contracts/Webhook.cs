using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class Webhook : IWebhook
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    [JsonPropertyName("settingsId")]
    public string SettingsId { get; set; } = string.Empty;
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("sentAt")]
    public DateTime? SentAt { get; set; }
    [JsonPropertyName("event")]
    [JsonConverter(typeof(Event.Converter))]
    public Event Event { get; set; }
    [JsonPropertyName("paymentMethod")]
    [JsonConverter(typeof(PaymentMethod.Converter))]
    public PaymentMethod PaymentMethod { get; set; }
    [JsonPropertyName("referenceIds")]
    public string[] ReferenceIds { get; set; } = Array.Empty<string>();
}
