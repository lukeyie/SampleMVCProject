using LukeTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LukeTest.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDAO>> GetAllOrdersAsync();
        Task<OrderDAO> GetOrderByIdAsync(int id);
        bool CreateOrder(OrderDAO order);
    }
}