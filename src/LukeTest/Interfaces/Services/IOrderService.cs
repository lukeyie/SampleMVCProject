using LukeTest.Models.DTO;

namespace LukeTest.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDetailDTO> GetOrderDetailsByGuid(string guid);
        IEnumerable<ShoppingCartDTO> GetShoppingCartInfo(string userId);
        IEnumerable<OrderDTO> GetOrdersByUserId(string userId);
        bool AddCartToOrder(string userId, string receiver, string email, string address);
        Task<bool> ApproveUserOrderDetails(string userId, string orderGuid);
    }
}