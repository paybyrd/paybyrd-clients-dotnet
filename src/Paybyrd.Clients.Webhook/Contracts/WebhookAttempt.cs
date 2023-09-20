using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookAttempt : IWebhookAttempt
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("webhookId")]
    public string WebhookId { get; set; } = string.Empty;

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("event")]
    [JsonConverter(typeof(Event.Converter))]
    public Event Event { get; set; }

    [JsonPropertyName("paymentMethod")]
    [JsonConverter(typeof(PaymentMethod.Converter))]
    public PaymentMethod PaymentMethod { get; set; }

    [JsonPropertyName("settings")]
    [JsonConverter(typeof(IWebhookAttemptSettings.Converter))]
    public IWebhookAttemptSettings Settings { get; set; } = null!;

    [JsonPropertyName("content")]
    public object Content { get; set; } = null!;

    [JsonPropertyName("response")]
    [JsonConverter(typeof(IWebhookAttemptResponse.Converter))]
    public IWebhookAttemptResponse Response { get; set; } = null!;
}
