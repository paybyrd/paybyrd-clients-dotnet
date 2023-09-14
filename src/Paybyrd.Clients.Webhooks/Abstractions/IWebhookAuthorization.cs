namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IWebhookAuthorization
{
    string Key { get; }
    string Value { get; }
}
