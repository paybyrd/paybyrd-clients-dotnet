using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Contracts;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttemptResponse
{
    HttpStatusCode StatusCode { get; }
    string? Content { get; }

    internal class Converter : JsonConverter<IWebhookAttemptResponse>
    {
        public override IWebhookAttemptResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<WebhookAttemptResponse>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IWebhookAttemptResponse value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
