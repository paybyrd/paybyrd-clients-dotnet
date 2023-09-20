using System.Text.Json;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Contracts;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttemptSettings
{
    /// <summary>
    ///     The password used to authenticate the webhook attempt.
    /// </summary>
    string Password { get; }

    /// <summary>
    ///     The URL to send the webhook attempt to.
    /// </summary>
    string Url { get; }

    /// <summary>
    ///     The username used to authenticate the webhook attempt.
    /// </summary>
    string Username { get; }

    internal class Converter : JsonConverter<IWebhookAttemptSettings>
    {
        public override IWebhookAttemptSettings? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<WebhookAttemptSettings>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IWebhookAttemptSettings value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
