namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAuthorization
{
    string Key { get; }
    string Value { get; }
}
