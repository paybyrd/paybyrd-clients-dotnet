namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IResendWebhooks
{
    string[] Ids { get; }
    string? Url { get; }
}
