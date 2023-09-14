using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhooks.Abstractions;

namespace Paybyrd.Clients.Webhooks.Contracts;

internal class WebhookAttempt : IWebhookAttempt
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    [JsonPropertyName("webhookId")]
    public string WebhookId { get; set; } = string.Empty;
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;
    [JsonPropertyName("paymentMethod")]
    public string PaymentMethod { get; set; } = string.Empty;
    [JsonPropertyName("settings")]
    [JsonConverter(typeof(IWebhookAttemptSettings.Converter))]
    public IWebhookAttemptSettings Settings { get; set; } = null!;
    [JsonPropertyName("content")]
    public object Content { get; set; } = null!;
    [JsonPropertyName("response")]
    [JsonConverter(typeof(IWebhookAttemptResponse.Converter))]
    public IWebhookAttemptResponse Response { get; set; } = null!;
}
