namespace Paybyrd.Clients.Webhook.Options;

public sealed class WebhookApiOptionsBuilder
{
    private string _baseUrl;
    private TimeSpan _timeout;

    internal WebhookApiOptionsBuilder()
    {
        _baseUrl = "https://webhook.paybyrd.com";
    }

    public WebhookApiOptionsBuilder WithBaseUrl(string url)
    {
        _baseUrl = url;
        return this;
    }

    public WebhookApiOptionsBuilder WithProductionBaseUrl()
    {
        _baseUrl = "https://webhook.paybyrd.com";
        return this;
    }

    public WebhookApiOptionsBuilder WithSandboxBaseUrl()
    {
        _baseUrl = "https://webhooksandbox.paybyrd.com";
        return this;
    }

    public WebhookApiOptionsBuilder WithTimeout(TimeSpan timeout)
    {
        _timeout = timeout;
        return this;
    }

    internal WebhookApiOptions Build()
    {
        return new WebhookApiOptions
        {
            BaseUrl = _baseUrl,
            Timeout = _timeout
        };
    }
}
