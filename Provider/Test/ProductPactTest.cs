using System;
using System.Collections.Generic;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit;
using Xunit.Abstractions;

namespace Provider.Test
{
    public class ProductPactTest : IClassFixture<ProviderPactTestFixture>
    {
        private readonly string _serviceUrl;
        private readonly ITestOutputHelper _outputHelper;

        public ProductPactTest(ProviderPactTestFixture fixture, ITestOutputHelper outputHelper)
        {
            _serviceUrl = fixture.Server.BaseAddress.AbsoluteUri;
            _outputHelper = outputHelper;
        }

        [Fact]
        public void EnsureProductPactTest()
        {
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_outputHelper)
                },
                Verbose = true
            };

            //Act & Assert
            var pactVerifier = new PactVerifier(config);
            pactVerifier
                .ProviderState($"{_serviceUrl}/provider-states")
                .ServiceProvider("Provider", _serviceUrl)
                .HonoursPactWith("Consumer")
                .PactUri("..\\..\\..\\pacts\\consumer-provider.json")
                .Verify();
        }
    }
}