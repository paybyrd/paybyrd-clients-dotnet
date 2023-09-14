namespace Paybyrd.Clients.Dotnet.Webhook.Abstractions;

public interface IResendWebhooks
{
    string[] Ids { get; }
    string? Url { get; }
}
