using System.Collections.Generic;
using System.Net;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace Consumer.Test
{
    public class ProductConsumerPactTest : IClassFixture<PactTestFixture>
    {
        private IMockProviderService _mockProviderService;
        public string _providerServiceUrl { get; set; }
        public ProductConsumerPactTest(PactTestFixture fixture)
        {
            _providerServiceUrl = fixture.ProviderServiceUrl;
            _mockProviderService = fixture.MockProviderService;
            _mockProviderService.ClearInteractions();
        }

        [Fact]
        public void Get_Single_Product_Return_Ok_Result()
        {
            _mockProviderService
                .Given("")
                .UponReceiving("A GET request to retrieve single product")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "products",
                    Headers = new Dictionary<string, object>
                    {
                        { "Accept", "application/json" }
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = (int)HttpStatusCode.OK,
                    Headers = new Dictionary<string, object>
                    {
                         { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {

                    }
                });



        }



    }
}

// public long Id { get; set; }
// public int CategoryId { get; set; }
// public string Name { get; set; }
// public decimal UnitPrice { get; set; }