using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDetailDAO> GetOrderDetailsByUserId(string userId, bool IsApproved);
        IEnumerable<OrderDAO> GetOrdersByUserId(string userId);
        bool AddCartToOrder(string userId, string receiver, string email, string address);
    }
}