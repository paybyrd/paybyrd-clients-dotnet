namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IAuthorization
{
    string Key { get; }
    string Value { get; }
}
