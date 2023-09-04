using Paybyrd.Clients.Webhook.Abstractions;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WebhookSettings : IWebhookSettings
{
    public string Id { get; init; } = string.Empty;
    public string Url { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string[] Events { get; init; } = Array.Empty<string>();
    public string[] Payments { get; init; } = Array.Empty<string>();
}
