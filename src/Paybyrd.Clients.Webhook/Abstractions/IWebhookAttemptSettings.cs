namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttemptSettings
{
    string Username { get; }
    string Password { get; }
    string Url { get; }
}
