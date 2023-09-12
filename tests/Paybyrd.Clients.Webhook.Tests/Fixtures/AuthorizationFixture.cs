using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Paybyrd.Clients.Webhook.Abstractions;
using Paybyrd.Clients.Webhook.Tests.Utils;

namespace Paybyrd.Clients.Webhook.Tests.Fixtures;

public class AuthorizationFixture
{
    public AuthorizationFixture()
    {
        Authorization = Substitute.For<IAuthorization>();
        Authorization.ApiKey.Returns(Configuration.Self.GetValue<string>("Webhook:ApiKey"));
    }

    public IAuthorization Authorization { get; }
}
