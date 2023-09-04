namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookSettings
{
    string Id { get; }
    string Url { get; }
    string Username { get; }
    string Password { get; }
    string[] Events { get; }
    string[] Payments { get; }
}
