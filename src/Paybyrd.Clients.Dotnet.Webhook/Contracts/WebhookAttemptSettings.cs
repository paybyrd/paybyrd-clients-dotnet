using System.Text.Json.Serialization;
using Paybyrd.Clients.Dotnet.Webhook.Abstractions;

namespace Paybyrd.Clients.Dotnet.Webhook.Contracts;

internal class WebhookAttemptSettings : IWebhookAttemptSettings
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
