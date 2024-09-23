using LukeTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LukeTest.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDAO>> GetAllProductsAsync();
        Task<ProductDAO> GetProductByIdAsync(int id);
    }
}