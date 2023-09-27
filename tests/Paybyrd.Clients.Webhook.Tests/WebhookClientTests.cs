using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Tests.Fixtures;
using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Tests;

public class WebhookClientTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _serviceProviderFixture;

    public WebhookClientTests(ServiceProviderFixture serviceProviderFixture)
    {
        _serviceProviderFixture = serviceProviderFixture ?? throw new ArgumentNullException(nameof(serviceProviderFixture));
    }

    [Fact]
    public async Task GivenWebhookClient_WhenCreateSettingsWithApiKeyAuthentication_ShouldReturnTheNewSettingsWithApiKeyCredential()
    {
        await using var sp = _serviceProviderFixture.BuildServiceProvider();
        var client = sp.GetRequiredService<IWebhookClient>();
        var createWebhookSettings = Substitute.For<ICreateWebhookSettings>();
        createWebhookSettings.Events.Returns(new[] { Event.OrderPaid });
        createWebhookSettings.PaymentMethods.Returns(new[] { PaymentMethod.Card });
        createWebhookSettings.Url.Returns("https://webapp-stub-api-v2-stg-ktzwiryfzguhy.azurewebsites.net/api/v1/hooks");
        createWebhookSettings.CredentialType.Returns(CredentialType.ApiKey);
        createWebhookSettings.ApiKey.Returns(Guid.NewGuid().ToString());
        var settings = await client.WebhookSettings.CreateAsync(createWebhookSettings);
        settings.Should().NotBeNull();

        settings.Id.Should().NotBeNull();
        settings.Url.Should().Be(createWebhookSettings.Url);
        settings.Credential.Should().NotBeNull();
        settings.Credential.Type.Should().Be(CredentialType.ApiKey.Value);
        settings.Credential.ApiKey.Should().Be(createWebhookSettings.ApiKey);
        settings.Events.Should().BeEquivalentTo(createWebhookSettings.Events);
        settings.PaymentMethods.Should().BeEquivalentTo(createWebhookSettings.PaymentMethods);
    }

    [Fact]
    public async Task GivenWebhookClient_WhenCreateSettingsWithBasicAuthentication_ShouldReturnTheNewSettingsWithBasicCredential()
    {
        await using var sp = _serviceProviderFixture.BuildServiceProvider();
        var client = sp.GetRequiredService<IWebhookClient>();
        var createWebhookSettings = Substitute.For<ICreateWebhookSettings>();
        createWebhookSettings.Events.Returns(new[] { Event.OrderPaid });
        createWebhookSettings.PaymentMethods.Returns(new[] { PaymentMethod.Card });
        createWebhookSettings.Url.Returns("https://webapp-stub-api-v2-stg-ktzwiryfzguhy.azurewebsites.net/api/v1/hooks");
        createWebhookSettings.Username.Returns(Guid.NewGuid().ToString());
        createWebhookSettings.Password.Returns(Guid.NewGuid().ToString());
        var settings = await client.WebhookSettings.CreateAsync(createWebhookSettings);
        settings.Should().NotBeNull();

        settings.Id.Should().NotBeNull();
        settings.Url.Should().Be(createWebhookSettings.Url);
        settings.Credential.Should().NotBeNull();
        settings.Credential.Type.Should().Be(CredentialType.Basic.Value);
        settings.Credential.Username.Should().Be(createWebhookSettings.Username);
        settings.Credential.Password.Should().Be(createWebhookSettings.Password);
        settings.Events.Should().BeEquivalentTo(createWebhookSettings.Events);
        settings.PaymentMethods.Should().BeEquivalentTo(createWebhookSettings.PaymentMethods);
    }

    [Fact]
    public async Task GivenWebhookClient_WhenDeleteSettings_ShouldDelete()
    {
        await using var sp = _serviceProviderFixture.BuildServiceProvider();
        var client = sp.GetRequiredService<IWebhookClient>();
        var createWebhookSettings = Substitute.For<ICreateWebhookSettings>();
        createWebhookSettings.StoreId.Returns(10);
        createWebhookSettings.Events.Returns(new[] { Event.OrderPaid });
        createWebhookSettings.PaymentMethods.Returns(new[] { PaymentMethod.Card });
        createWebhookSettings.Url.Returns("https://webapp-stub-api-v2-stg-ktzwiryfzguhy.azurewebsites.net/api/v1/hooks");
        createWebhookSettings.Username.Returns(Guid.NewGuid().ToString());
        createWebhookSettings.Password.Returns(Guid.NewGuid().ToString());
        var settings = await client.WebhookSettings.CreateAsync(createWebhookSettings);
        settings.Should().NotBeNull();
        settings.Id.Should().NotBeNull();

        var deleteWebhookSettings = Substitute.For<IDeleteWebhookSettings>();
        deleteWebhookSettings.SettingsId.Returns(settings.Id);
        var action = () => client.WebhookSettings.DeleteAsync(deleteWebhookSettings);
        action.Should().NotThrow();
    }

    [Fact]
    public async Task GivenWebhookClient_WhenQuerySettings_ShouldReturnAList()
    {
        await using var sp = _serviceProviderFixture.BuildServiceProvider();
        var client = sp.GetRequiredService<IWebhookClient>();
        var querySettings = Substitute.For<IQueryWebhookSettings>();
        querySettings.StoreIds.Returns(Array.Empty<long>());
        var settings = await client.WebhookSettings.QueryAsync(querySettings);
        settings.Should().NotBeEmpty();
    }

    [Fact(Skip = "This test requires a valid webhook id.")]
    public async Task GivenWebhookClient_WhenQueryWebhookAttempts_ShouldReturnAList()
    {
        await using var sp = _serviceProviderFixture.BuildServiceProvider();
        var client = sp.GetRequiredService<IWebhookClient>();
        var queryWebhookAttempts = Substitute.For<IQueryWebhookAttempts>();
        queryWebhookAttempts.WebhookId.Returns("df49bf90-e9d3-4578-8cb2-7c66f84e95a9");
        var webhookAttempts = await client.Webhooks.QueryAsync(queryWebhookAttempts);
        webhookAttempts.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GivenWebhookClient_WhenQueryWebhooks_ShouldReturnAList()
    {
        await using var sp = _serviceProviderFixture.BuildServiceProvider();
        var client = sp.GetRequiredService<IWebhookClient>();
        var queryWebhooks = Substitute.For<IQueryWebhooks>();
        var webhooks = await client.Webhooks.QueryAsync(queryWebhooks);
        webhooks.Should().NotBeEmpty();
    }
}
