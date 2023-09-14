namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface ICreateWebhookSettings
{
    long StoreId { get; }
    string Url { get; }
    string Username { get; }
    string Password { get; }
    string[] Events { get; }
    string[] PaymentMethods { get; }
}
