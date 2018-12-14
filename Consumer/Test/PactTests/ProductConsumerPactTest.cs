using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Provider.Model;
using Xunit;

namespace Consumer.Test
{
    public class ProductConsumerPactTest : IClassFixture<PactTestFixture>
    {
        private IMockProviderService _mockProviderService;
        private string _providerServiceUrl { get; set; }
        public ProductConsumerPactTest(PactTestFixture fixture)
        {
            _providerServiceUrl = fixture.ProviderServiceUrl;
            _mockProviderService = fixture.MockProviderService;
            _mockProviderService.ClearInteractions();
        }

        [Fact]
        public async Task Get_Single_Product_Return_Ok_Result()
        {
            var testRecordId = 1;

            _mockProviderService
                .Given("There is single data.")
                .UponReceiving("A GET request to retrieve single product")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = $"/api/products/{testRecordId}",
                    // Headers = new Dictionary<string, object>
                    // {
                    //     { "Accept", "application/json" }
                    // }
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
                        id = testRecordId,
                        CategoryId = 2,
                        Name = "Printer",
                        UnitPrice = 200
                    }
                });

            using (var client = new HttpClient { BaseAddress = new Uri(_providerServiceUrl) })
            {
                var response = await client.GetAsync($"/api/products/{testRecordId}");
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ProductModel>(content);

                Assert.True(response.StatusCode == HttpStatusCode.OK);
                Assert.True(model.Id == testRecordId);
            }
        }
    }
}