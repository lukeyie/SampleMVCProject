using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDetailDAO> GetOrderDetailByUserId(string userId, bool IsApproved);
        bool AddCartToOrder(string userId, string receiver, string email, string address);
    }
}