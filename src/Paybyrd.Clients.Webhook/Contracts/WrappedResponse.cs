using System.Text.Json.Serialization;

namespace Paybyrd.Clients.Webhook.Contracts;

internal class WrappedResponse<T>
{
    [JsonPropertyName("data")]
    public T Data {get; set; } = default!;
}
