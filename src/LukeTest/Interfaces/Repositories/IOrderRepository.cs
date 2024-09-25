using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDAO>> GetAllOrdersAsync();
        Task<OrderDAO> GetOrderByIdAsync(int id);
        bool CreateOrder(OrderDAO order);
    }
}