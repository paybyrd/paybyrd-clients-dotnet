using System.Text.Json;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Contracts;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttemptSettings
{
    string Username { get; }
    string Password { get; }
    string Url { get; }

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
