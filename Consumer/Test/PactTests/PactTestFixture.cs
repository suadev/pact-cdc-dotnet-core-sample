using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace Consumer.Test
{
    public class PactTestFixture : IDisposable
    {
        public IPactBuilder PactBuilder { get; set; }
        public IMockProviderService MockProviderService { get; set; }
        public static int MockServicePort = 9222;
        public string ProviderServiceUrl = $"http://localhost:{MockServicePort}";

        public PactTestFixture()
        {
            var pactConfig = new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"..\..\..\..\..\contracts",
                LogDir = @".\pact_logs"
            };
            PactBuilder = new PactBuilder();
            PactBuilder.ServiceConsumer("ConsumerMicroservice").HasPactWith("ProviderMicroservice");
            MockProviderService = PactBuilder.MockService(MockServicePort);
        }

        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // This will save the pact file once finished.
                    PactBuilder.Build();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}