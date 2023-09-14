using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhooks.Abstractions;

namespace Paybyrd.Clients.Webhooks.Contracts;

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
    public string[] Events { get; set; } = Array.Empty<string>();
    [JsonPropertyName("paymentMethods")]
    public string[] PaymentMethods { get; set; } = Array.Empty<string>();
}
