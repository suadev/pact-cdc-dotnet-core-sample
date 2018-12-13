using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace Consumer.Test
{
    public class PactTestFixture : IDisposable
    {
        public IPactBuilder PactBuilder { get; set; }
        public IMockProviderService MockProviderService { get; set; }
        public static int MockServicePort = 5000;
        public string ProviderServiceUrl = $"http://localhost:{MockServicePort}/api/";

        public PactTestFixture()
        {
            PactBuilder = new PactBuilder();

            PactBuilder.ServiceConsumer("Consumer")
                        .HasPactWith("Provider");

            MockProviderService = PactBuilder.MockService(MockServicePort);
        }

        public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}