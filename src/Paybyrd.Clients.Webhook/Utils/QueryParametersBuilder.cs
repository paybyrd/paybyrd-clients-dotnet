using System.Collections.Specialized;

namespace Paybyrd.Clients.Webhook.Utils;

internal sealed class QueryParametersBuilder
{
    private readonly NameValueCollection _nameValueCollection = new();

    public QueryParametersBuilder Add(string key, string? value)
    {
        if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
        {
            return this;
        }
        _nameValueCollection.Add(key, value);
        return this;
    }
    
    public QueryParametersBuilder Add(string key, IEnumerable<string?> values)
    {
        foreach (var value in values)
        {
            Add(key, value);
        }

        return this;
    }

    public string Build()
    {
        return "?" + string.Join(
            '&',
            _nameValueCollection.AllKeys
            .Select(key => $"{key}={_nameValueCollection[key]}"));
    }
}
