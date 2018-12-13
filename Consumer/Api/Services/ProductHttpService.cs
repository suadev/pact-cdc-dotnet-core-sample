using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Provider.Model;

namespace Consumer.Services
{
    public class ProductHttpService : IProductHttpService
    {
        private readonly HttpClient _httpClient;
        public ProductHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductModel> GetProduct(long id)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, $"products/{id}"))
            {
                var response = await _httpClient.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ProductModel>(content);
                }
                throw new Exception($"Product service connection error.Status Code: {response.StatusCode}");
            }
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "products"))
            {
                var response = await _httpClient.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ProductModel>>(content);
                }
                throw new Exception($"Product service connection error.Status Code: {response.StatusCode}");
            }
        }
    }
}