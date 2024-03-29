﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Paybyrd.Clients.Webhook.Contracts;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttemptSettings
{
    /// <summary>
    ///     The credential used to authenticate the webhook attempt.
    /// </summary>
    IWebhookCredential Credential { get; }

    /// <summary>
    ///     The URL to send the webhook attempt to.
    /// </summary>
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
