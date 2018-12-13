using System.Collections.Generic;
using System.Threading.Tasks;
using Provider.Model;

namespace Consumer.Services
{
    public interface IProductHttpService
    {
        Task<List<ProductModel>> GetProducts();
    }
}