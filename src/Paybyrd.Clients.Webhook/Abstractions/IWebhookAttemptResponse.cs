using System.Net;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface IWebhookAttemptResponse
{
    HttpStatusCode StatusCode { get; }
    string? Content { get; }
}
