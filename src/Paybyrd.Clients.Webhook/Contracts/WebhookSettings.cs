using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookSettings : IWebhookSettings
{
    [JsonPropertyName("credential")]
    [JsonConverter(typeof(IWebhookCredential.Converter))]
    public IWebhookCredential Credential { get; set; } = null!;

    [JsonPropertyName("events")]
    [JsonConverter(typeof(Event.ArrayConverter))]
    public Event[] Events { get; set; } = Array.Empty<Event>();

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("paymentMethods")]
    [JsonConverter(typeof(PaymentMethod.ArrayConverter))]
    public PaymentMethod[] PaymentMethods { get; set; } = Array.Empty<PaymentMethod>();

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
