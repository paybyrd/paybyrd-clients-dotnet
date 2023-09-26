using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttempt : IWebhookAttempt
{
    [JsonPropertyName("content")]
    public object Content { get; set; } = null!;

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("paymentMethod")]
    public string PaymentMethod { get; set; } = string.Empty;

    [JsonPropertyName("response")]
    [JsonConverter(typeof(IWebhookAttemptResponse.Converter))]
    public IWebhookAttemptResponse Response { get; set; } = null!;

    [JsonPropertyName("settings")]
    [JsonConverter(typeof(IWebhookAttemptSettings.Converter))]
    public IWebhookAttemptSettings Settings { get; set; } = null!;

    [JsonPropertyName("webhookId")]
    public string WebhookId { get; set; } = string.Empty;
}
