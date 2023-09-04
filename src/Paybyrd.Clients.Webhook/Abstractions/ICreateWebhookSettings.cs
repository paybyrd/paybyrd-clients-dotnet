namespace Paybyrd.Clients.Webhook.Abstractions;

public interface ICreateWebhookSettings
{
    string Url { get; }
    string Username { get; }
    string Password { get; }
    string[] Events { get; }
    string[] PaymentMethods { get; }
}
