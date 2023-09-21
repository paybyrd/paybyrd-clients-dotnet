using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class CreateWebhookSettingsRequest : ICreateWebhookSettings
{
    private readonly ICreateWebhookSettings _createWebhookSettings;

    public CreateWebhookSettingsRequest(ICreateWebhookSettings createWebhookSettings)
    {
        _createWebhookSettings = createWebhookSettings ?? throw new ArgumentNullException(nameof(createWebhookSettings));
    }

    [JsonPropertyName("apiKey")]
    public string ApiKey => _createWebhookSettings.ApiKey;

    [JsonPropertyName("credentialType")]
    [JsonConverter(typeof(CredentialType.Converter))]
    public CredentialType CredentialType => _createWebhookSettings.CredentialType;

    [JsonPropertyName("events")]
    [JsonConverter(typeof(Event.ArrayConverter))]
    public Event[] Events => _createWebhookSettings.Events;

    [JsonPropertyName("password")]
    public string? Password => _createWebhookSettings.Password;

    [JsonPropertyName("paymentMethods")]
    [JsonConverter(typeof(PaymentMethod.ArrayConverter))]
    public PaymentMethod[] PaymentMethods => _createWebhookSettings.PaymentMethods;

    [JsonPropertyName("storeId")]
    public long StoreId => _createWebhookSettings.StoreId;

    [JsonPropertyName("url")]
    public string Url => _createWebhookSettings.Url;

    [JsonPropertyName("username")]
    public string? Username => _createWebhookSettings.Username;
}
