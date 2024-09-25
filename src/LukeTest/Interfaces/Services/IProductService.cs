using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDAO>> GetAllProductsAsync();
    }
}