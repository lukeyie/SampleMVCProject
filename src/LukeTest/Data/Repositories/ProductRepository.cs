using LukeTest.Models;
using Newtonsoft.Json;

namespace LukeTest.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _filePath;

        public ProductRepository(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "table_Product.json");
        }

        public async Task<IEnumerable<ProductDAO>> GetAllProductsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDAO>>(jsonData);
            return products;
        }

        public async Task<ProductDAO> GetProductByIdAsync(int id)
        {
            var products = await GetAllProductsAsync();
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}