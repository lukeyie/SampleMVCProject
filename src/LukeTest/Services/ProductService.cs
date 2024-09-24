using LukeTest.Data.Repositories;
using LukeTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LukeTest.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDAO>> GetAllProductsAsync()
        {
            IEnumerable<ProductDAO> _products = await _productRepository.GetAllProductsAsync();
            if(_products == null || !_products.Any())
            {
                _logger.LogWarning("No products found.");
                return null;
            }
            
            return _products;
        }
    }
}