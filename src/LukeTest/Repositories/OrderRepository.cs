using LukeTest.Interfaces.Repositories;
using LukeTest.Models.DAO;
using Newtonsoft.Json;

namespace LukeTest.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _filePath;

        public OrderRepository(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "table_Order.json");
        }

        public async Task<IEnumerable<OrderDAO>> GetAllOrdersAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var orders = JsonConvert.DeserializeObject<IEnumerable<OrderDAO>>(jsonData) ?? Enumerable.Empty<OrderDAO>();
            return orders;
        }

        public async Task<OrderDAO> GetOrderByIdAsync(int id)
        {
            var orders = await GetAllOrdersAsync();
            return orders.FirstOrDefault(o => o.Id == id) ?? new OrderDAO();
        }

        public bool CreateOrder(OrderDAO order)
        {
            var orders = GetAllOrdersAsync().Result.ToList();
            order.Id = orders.Count == 0 ? 1 : orders.Max(o => o.Id) + 1;
            orders.Add(order);
            var jsonData = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
            return true;
        }
    }
}