namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IQueryWebhookSettingsById
{
    /// <summary>
    ///     The ID of the webhook settings to query.
    /// </summary>
    string SettingsId { get; }
}
