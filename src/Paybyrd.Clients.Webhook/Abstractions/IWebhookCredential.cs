using System.Text.Json;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Contracts;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookCredential
{
    string? ApiKey { get; }
    string? Password { get; }
    CredentialType Type { get; }
    string? Username { get; }

    internal class Converter : JsonConverter<IWebhookCredential>
    {
        public override IWebhookCredential? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<WebhookCredential>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IWebhookCredential value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
