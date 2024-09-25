using LukeTest.Interfaces.Repositories;
using LukeTest.Interfaces.Services;
using LukeTest.Models.DAO;
using LukeTest.Models.DTO;

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

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            IEnumerable<ProductDAO> products = await _productRepository.GetAllProductsAsync();
            if(products == null || !products.Any())
            {
                _logger.LogWarning("No products found.");
                return null;
            }

            List<ProductDTO> productDTOs = new();
            foreach(var product in products)
            {
                productDTOs.Add(new ProductDTO
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Image = product.Image
                });
            }
            
            return productDTOs;
        }
    }
}