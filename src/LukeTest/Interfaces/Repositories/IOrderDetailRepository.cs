using LukeTest.Models.DAO;

namespace LukeTest.Interfaces.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetailDAO>> GetAllOrderDetailsAsync();
        Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByGuidAsync(string guid);
        Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByUserIdAndIsApprovedAsync(string userId, bool isApproved);
        Task<bool> ApproveUserOrderDetails(string userId, string orderGuid);
    }
}