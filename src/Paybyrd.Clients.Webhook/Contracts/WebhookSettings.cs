using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookSettings : IWebhookSettings
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
    [JsonPropertyName("events")]
    [JsonConverter(typeof(Event.ArrayConverter))]
    public Event[] Events { get; set; } = Array.Empty<Event>();
    [JsonPropertyName("paymentMethods")]
    [JsonConverter(typeof(PaymentMethod.ArrayConverter))]
    public PaymentMethod[] PaymentMethods { get; set; } = Array.Empty<PaymentMethod>();
}
