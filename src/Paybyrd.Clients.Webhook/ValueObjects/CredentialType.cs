using System.Text.Json;
using System.Text.Json.Serialization;

namespace Paybyrd.Clients.Webhook.ValueObjects;

public readonly record struct CredentialType
{
    private const string API_KEY = "api-key";
    private const string BASIC = "basic";

    private CredentialType(string value)
    {
        Value = value;
    }

    public static CredentialType ApiKey => new(API_KEY);

    public static CredentialType Basic => new(BASIC);

    public string Value { get; }

    public static CredentialType Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Basic;
        }

        return new CredentialType(value);
    }

    internal class Converter : JsonConverter<CredentialType>
    {
        public override CredentialType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var credentialType = JsonSerializer.Deserialize<string>(ref reader, options) ?? string.Empty;
            return Create(credentialType);
        }

        public override void Write(Utf8JsonWriter writer, CredentialType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}
