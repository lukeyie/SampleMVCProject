using System.Text.Json;
using LukeTest.Interfaces.Repositories;
using LukeTest.Models.DAO;

namespace LukeTest.Tests.Mocks.Repositories
{
    public class MockOrderRepository : IOrderRepository
    {
        private readonly string _jsonPath = "TestData/order.json";

        public async Task<IEnumerable<OrderDAO>> GetAllOrdersAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var orders = JsonSerializer.Deserialize<IEnumerable<OrderDAO>>(jsonData);
            return orders;
        }

        public async Task<IEnumerable<OrderDAO>> GetOrderByUserIdAsync(string userId)
        {
            var jsonData = await File.ReadAllTextAsync(_jsonPath);
            var orders = JsonSerializer.Deserialize<IEnumerable<OrderDAO>>(jsonData);
            return orders.Where(o => o.Username == userId);
        }

        public bool CreateOrder(OrderDAO order)
        {
            return true;
        }
    }
}