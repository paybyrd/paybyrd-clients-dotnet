using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Contracts;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttemptResponse
{
    /// <summary>
    /// The status code response of the webhook attempt.
    /// </summary>
    HttpStatusCode StatusCode { get; }
    /// <summary>
    /// The content response of the webhook attempt.
    /// </summary>
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
