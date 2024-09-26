using LukeTest.Interfaces.Repositories;
using LukeTest.Models.DAO;
using Newtonsoft.Json;

namespace LukeTest.Tests.Mocks.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private readonly string _jsonPath = "TestData/product.json";

        public async Task<IEnumerable<ProductDAO>> GetAllProductsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDAO>>(jsonData);
            return products;
        }

        public async Task<ProductDAO> GetProductByIdAsync(int id)
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDAO>>(jsonData);
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}