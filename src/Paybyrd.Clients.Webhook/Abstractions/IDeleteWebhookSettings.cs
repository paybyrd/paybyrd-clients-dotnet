namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IDeleteWebhookSettings
{
    /// <summary>
    /// The ID of the webhook settings to delete.
    /// </summary>
    string SettingsId { get; }
}
