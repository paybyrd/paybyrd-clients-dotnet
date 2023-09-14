namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IWebhookAuthorization
{
    string Key { get; }
    string Value { get; }
}
