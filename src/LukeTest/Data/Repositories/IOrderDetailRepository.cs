using LukeTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LukeTest.Data.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetailDAO>> GetAllOrderDetailsAsync();
        Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByUserIdAndIsApprovedAsync(string userId, bool isApproved);
    }
}