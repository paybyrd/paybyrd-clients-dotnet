using System.Text.Json.Serialization;

namespace Paybyrd.Clients.Dotnet.Webhook.Contracts;

internal class WrappedResponse<T>
{
    [JsonPropertyName("data")]
    public T Data {get; set; } = default!;
}
