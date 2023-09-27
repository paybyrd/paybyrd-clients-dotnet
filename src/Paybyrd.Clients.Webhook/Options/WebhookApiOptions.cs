namespace Paybyrd.Clients.Webhook.Options;

public class WebhookApiOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    internal Type? HttpHandlerType { get; set; }
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(10);

    internal void Update(WebhookApiOptions options)
    {
        BaseUrl = options.BaseUrl;
        Timeout = options.Timeout;
        HttpHandlerType = options.HttpHandlerType;
    }
}
