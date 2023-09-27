# Paybyrd.Clients

Projeto de clients criados especificamente para consumir APIs RESTful públicas da Paybyrd.

## Paybyrd.Clients.Webhook

Client para consumir a API de Webhooks da Paybyrd.

### Instalação

```bash
dotnet add package Paybyrd.Clients.Webhook
```

### Como configurar

Dentro do método `ConfigureServices` da sua aplicação, ou `Program.cs`, caso esteja utilizando as novas versões do .Net,
adicione o seguinte código:

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

Para criar a classe de autenticação, basta implementar a interface `IWebhookAuthorizationHandler`, segue um exemplo abaixo:
    
```csharp
public class WebhookAuthorizationHandler : IWebhookAuthorizationHandler
{
    public async ValueTask<IWebhookAuthorization> GetAuthorizationAsync(CancellationToken cancellationToken)
    {
        // Aqui você pode fazer uma autenticação Machine to machine ou utilizar a API Key da Paybyrd.
    }
}
```

### Como utilizar

Para utilizar o client, basta injetar a interface `IWebhookClient` no construtor da sua classe e utilizar os métodos disponíveis.

```csharp
using Paybyrd.Clients.Webhook;

public class WebhookExternalService
{
    private readonly IWebhookClient _webhookClient;

    public WebhookService(IWebhookClient webhookClient)
    {
        _webhookClient = webhookClient ?? throw new ArgumentNullException(nameof(webhookClient));
    }
    
    // Implemente a chamada dos métodos que deseja utilizar.
}
```

### Métodos disponíveis

#### Resend webhooks

Permite reenviar uma lista de webhooks.

```csharp
IResendWebhooks resendWebhooks = // Implemente uma classe que implemente `IResendWebhooks`.
await _webhookClient.Webhooks.ResendAsync(resendWebhooks, cancellationToken);
```

#### Query webhooks

Permite consultar uma lista de webhooks com alguns filtros disponíveis.

```csharp
IQueryWebhooks queryWebhooks = // Implemente uma classe de filtro que implement `IQueryWebhooks`.
IWebhookCollection webhooks = await _webhookClient.Webhooks.QueryAsync(queryWebhooks, cancellationToken);
```

#### Query webhook attempts

Permite consultar uma lista de tentativas de envio para um webhook.

```csharp
IQueryWebhookAttempts queryWebhookAttempts = // Implemente uma classe de filtro que implement `IQueryWebhookAttempts`.
IWebhookAttemptCollection webhookAttempts = await _webhookClient.Webhooks.QueryAsync(queryAttempts, cancellationToken);
```

#### Create webhook settings

Permite criar uma configuração de webhook.

```csharp
ICreateWebhookSettings = // Implemente uma classe que implemente `ICreateWebhookSettings`.
IWebhookSettings settings = await _webhookClient.WebhookSettings.CreateAsync(createWebhookSettings, cancellationToken);
```

#### Delete webhook settings

Permite deletar uma configuração de webhook.

```csharp
IDeleteWebhookSettings deleteWebhookSettings = // Implemente uma classe que implemente `IDeleteWebhookSettings`.
await _webhookClient.WebhookSettings.DeleteAsync(deleteWebhookSettings, cancellationToken);
```

#### Query webhook settings

Permite consultar uma lista de configurações de webhook.

```csharp
IQueryWebhookSettings queryWebhookSettings = // Implemente uma classe de filtro que implemente `IQueryWebhookSettings`.
IWebhookSettingsCollection webhookSettings = await _webhookClient.WebhookSettings.DeleteAsync(queryWebhookSettings, cancellationToken);
```

#### Query a webhook settings by id

Permite consultar uma configuração de webhook pelo seu id.

```csharp
IQueryWebhookSettingsById queryWebhookSettingsById = // Implemente uma classe de filtro que implemente `IQueryWebhookSettingsById`.
IWebhookSettings webhookSettings = await _webhookClient.WebhookSettings.QueryAsync(queryWebhookSettingsById, cancellationToken);
```