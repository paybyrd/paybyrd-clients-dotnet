# Paybyrd.Clients

Client projects created specifically to consume Paybyrd's public RESTful APIs.

## Paybyrd.Clients.Webhook

Client for consuming Paybyrd's Webhooks API.

### Installation

```bash
dotnet add package Paybyrd.Clients.Webhook
```

### How to Configure

Inside the `ConfigureServices` method of your application, or in `Program.cs` if you are using the newer versions of .NET, add the following code:

```csharp
using Paybyrd.Clients.Webhook;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<LoggerHttpHandler>();
builder.Services.AddWebhookClient<WebhookAuthorizationHandler>(builder =>
{
    builder
        .WithProductionBaseUrl()
        .WithTimeout(TimeSpan.FromSeconds(30))
        .WithHttpHandler<LoggerHttpHandler>();
});
```

To create the authentication class, simply implement the `IWebhookAuthorizationHandler` interface, as shown in the example below:

```csharp
public class WebhookAuthorizationHandler : IWebhookAuthorizationHandler
{
    public async ValueTask<IWebhookAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken)
    {
        // Here you can perform machine-to-machine authentication or use Paybyrd's API Key.
    }
}
```

### How to Use

To use the client, simply inject the `IWebhookClient` interface into your class constructor and use the available methods.

```csharp
using Paybyrd.Clients.Webhook;

public class WebhookExternalService
{
    private readonly IWebhookClient _webhookClient;

    public WebhookService(IWebhookClient webhookClient)
    {
        _webhookClient = webhookClient ?? throw new ArgumentNullException(nameof(webhookClient));
    }
    
    // Implement the calls to the methods you want to use.
}
```

### Available Methods

#### Resend Webhooks

Allows you to resend a list of webhooks.

```csharp
IResendWebhooks resendWebhooks = // Implement a class that implements `IResendWebhooks`.
await _webhookClient.Webhooks.ResendAsync(resendWebhooks, cancellationToken);
```

#### Query Webhooks

Allows you to query a list of webhooks with various available filters.

```csharp
IQueryWebhooks queryWebhooks = // Implement a filter class that implements `IQueryWebhooks`.
IWebhookCollection webhooks = await _webhookClient.Webhooks.QueryAsync(queryWebhooks, cancellationToken);
```

#### Query Webhook Attempts

Allows you to query a list of send attempts for a webhook.

```csharp
IQueryWebhookAttempts queryWebhookAttempts = // Implement a filter class that implements `IQueryWebhookAttempts`.
IWebhookAttemptCollection webhookAttempts = await _webhookClient.Webhooks.QueryAsync(queryAttempts, cancellationToken);
```

#### Create Webhook Settings

Allows you to create webhook settings.

```csharp
ICreateWebhookSettings createWebhookSettings = // Implement a class that implements `ICreateWebhookSettings`.
IWebhookSettings settings = await _webhookClient.WebhookSettings.CreateAsync(createWebhookSettings, cancellationToken);
```

#### Delete Webhook Settings

Allows you to delete webhook settings.

```csharp
IDeleteWebhookSettings deleteWebhookSettings = // Implement a class that implements `IDeleteWebhookSettings`.
await _webhookClient.WebhookSettings.DeleteAsync(deleteWebhookSettings, cancellationToken);
```

#### Query Webhook Settings

Allows you to query a list of webhook settings.

```csharp
IQueryWebhookSettings queryWebhookSettings = // Implement a filter class that implements `IQueryWebhookSettings`.
IWebhookSettingsCollection webhookSettings = await _webhookClient.WebhookSettings.DeleteAsync(queryWebhookSettings, cancellationToken);
```

#### Query Webhook Settings by ID

Allows you to query webhook settings by their ID.

```csharp
IQueryWebhookSettingsById queryWebhookSettingsById = // Implement a filter class that implements `IQueryWebhookSettingsById`.
IWebhookSettings webhookSettings = await _webhookClient.WebhookSettings.QueryAsync(queryWebhookSettingsById, cancellationToken);
```