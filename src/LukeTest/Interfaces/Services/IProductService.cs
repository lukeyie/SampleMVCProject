using LukeTest.Models.DTO;

namespace LukeTest.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    }
}