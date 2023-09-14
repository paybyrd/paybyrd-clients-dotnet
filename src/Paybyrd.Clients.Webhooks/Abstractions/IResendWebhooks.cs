namespace Paybyrd.Clients.Webhooks.Abstractions;

public interface IResendWebhooks
{
    string[] Ids { get; }
    string? Url { get; }
}
