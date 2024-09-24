using LukeTest.Models;

namespace LukeTest.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDAO>> GetAllProductsAsync();
    }
}