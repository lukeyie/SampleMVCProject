using System.Text.Json;
using LukeTest.Interfaces.Repositories;
using LukeTest.Models.DAO;

namespace LukeTest.Tests.Mocks.Repositories
{
    public class MockOrderDetailRepository : IOrderDetailRepository
    {
        private readonly string _jsonPath = "TestData/order_detail.json";
        
        public async Task<IEnumerable<OrderDetailDAO>> GetAllOrderDetailsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var orderDetails = JsonSerializer.Deserialize<IEnumerable<OrderDetailDAO>>(jsonData);
            return orderDetails;
        }

        public async Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByGuidAsync(string guid)
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var orderDetails = JsonSerializer.Deserialize<IEnumerable<OrderDetailDAO>>(jsonData);
            return orderDetails.Where(o => o.Guid == guid);
        }

        public async Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByUserIdAndIsApprovedAsync(string userId, bool isApproved)
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var orderDetails = JsonSerializer.Deserialize<IEnumerable<OrderDetailDAO>>(jsonData);
            string isApprovedStr = isApproved ? "是" : "否";
            return orderDetails.Where(o => o.Username == userId && o.IsApproved == isApprovedStr);
        }

        public async Task<bool> UpdateOrderDetails(IEnumerable<OrderDetailDAO> orderDetails)
        {
            return true;
        }
    }
}