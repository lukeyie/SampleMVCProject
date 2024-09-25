using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDAO>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDAO>> GetOrderByUserIdAsync(string userId);
        bool CreateOrder(OrderDAO order);
    }
}