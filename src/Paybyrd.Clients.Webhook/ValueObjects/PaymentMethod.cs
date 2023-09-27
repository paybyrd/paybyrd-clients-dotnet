using System.Text.Json;
using System.Text.Json.Serialization;

namespace Paybyrd.Clients.Webhook.ValueObjects;

public readonly record struct PaymentMethod
{
    private const string BANKTRANSFER = "banktransfer";
    private const string CARD = "card";
    private const string FLOA = "floa";
    private const string IDEAL = "ideal";
    private const string MBWAY = "mbway";
    private const string MULTIBANCO = "multibanco";
    private const string MULTICAIXA = "multicaixa";
    private const string NONE = "none";
    private const string PAYPAL = "paypal";
    private const string PICKUP = "pickup";

    private PaymentMethod(string value)
    {
        Value = value;
    }

    public static PaymentMethod BankTransfer => new(BANKTRANSFER);
    public static PaymentMethod Card => new(CARD);
    public static PaymentMethod Floa => new(FLOA);
    public static PaymentMethod Ideal => new(IDEAL);
    public static PaymentMethod MbWay => new(MBWAY);
    public static PaymentMethod Multibanco => new(MULTIBANCO);
    public static PaymentMethod Multicaixa => new(MULTICAIXA);

    public static PaymentMethod None => new(NONE);
    public static PaymentMethod PayPal => new(PAYPAL);
    public static PaymentMethod PickUp => new(PICKUP);

    public string Value { get; }

    public static PaymentMethod Create(string? paymentMethod)
    {
        if (string.IsNullOrWhiteSpace(paymentMethod))
        {
            return None;
        }

        return new PaymentMethod(paymentMethod);
    }

    internal class ArrayConverter : JsonConverter<PaymentMethod[]>
    {
        public override PaymentMethod[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var paymentMethods = JsonSerializer.Deserialize<string[]>(ref reader, options) ?? Array.Empty<string>();
            return paymentMethods.Select(Create).ToArray();
        }

        public override void Write(Utf8JsonWriter writer, PaymentMethod[] value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Select(x => x.Value).ToArray(), options);
        }
    }

    internal class Converter : JsonConverter<PaymentMethod>
    {
        public override PaymentMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var paymentMethod = JsonSerializer.Deserialize<string>(ref reader, options);
            return Create(paymentMethod);
        }

        public override void Write(Utf8JsonWriter writer, PaymentMethod value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}
