using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDAO>> GetAllProductsAsync();
        Task<ProductDAO> GetProductByIdAsync(int id);
    }
}