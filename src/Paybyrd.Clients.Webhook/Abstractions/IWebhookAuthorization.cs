namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAuthorization
{
    /// <summary>
    ///     The header key.
    /// </summary>
    string Key { get; }

    /// <summary>
    ///     The value of the header key.
    /// </summary>
    string Value { get; }
}
