using LukeTest.Models;
namespace LukeTest.Data.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetailDAO>> GetAllOrderDetailsAsync();
        Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByUserIdAndIsApprovedAsync(string userId, bool isApproved);
        Task<bool> ApproveUserOrderDetails(string userId, string orderGuid);
    }
}