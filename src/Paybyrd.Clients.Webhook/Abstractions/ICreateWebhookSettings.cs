using Paybyrd.Clients.Webhook.ValueObjects;

namespace Paybyrd.Clients.Webhook.Abstractions;

public interface ICreateWebhookSettings
{
    /// <summary>
    ///     The API key to use for API key authentication.
    /// </summary>
    /// <remarks>
    ///     Available if <see cref="CredentialType" /> is <c>api-key</c>.
    /// </remarks>
    /// <remarks>
    ///     If not provided and <see cref="CredentialType" /> is <c>api-key</c>, it will be generated.
    /// </remarks>
    string ApiKey { get; }

    /// <summary>
    ///     The authorization type to use.
    /// </summary>
    /// <remarks>
    ///     Supports <c>basic</c> and <c>api-key</c>.
    /// </remarks>
    CredentialType CredentialType { get; }

    /// <summary>
    ///     The events to send hooks for.
    /// </summary>
    Event[] Events { get; }

    /// <summary>
    ///     The password to use for basic authentication.
    /// </summary>
    /// <remarks>
    ///     Available if <see cref="CredentialType" /> is <c>basic</c>.
    /// </remarks>
    /// <remarks>
    ///     If not provided and <see cref="CredentialType" /> is <c>basic</c>, it will be generated.
    /// </remarks>
    string? Password { get; }

    /// <summary>
    ///     The payment methods to send hooks for.
    /// </summary>
    PaymentMethod[] PaymentMethods { get; }

    /// <summary>
    ///     The ID of the store to create the webhook settings for.
    /// </summary>
    long StoreId { get; }

    /// <summary>
    ///     The URL to send the hooks to.
    /// </summary>
    string Url { get; }

    /// <summary>
    ///     The username to use for basic authentication.
    /// </summary>
    /// <remarks>
    ///     Available if <see cref="CredentialType" /> is <c>basic</c>.
    /// </remarks>
    /// <remarks>
    ///     If not provided and <see cref="CredentialType" /> is <c>basic</c>, it will be generated.
    /// </remarks>
    string? Username { get; }
}
