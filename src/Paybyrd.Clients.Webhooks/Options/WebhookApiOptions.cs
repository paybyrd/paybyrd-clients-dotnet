namespace Paybyrd.Clients.Webhooks.Options;

public class WebhookApiOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(10);
}
