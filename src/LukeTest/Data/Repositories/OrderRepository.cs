using LukeTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace LukeTest.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _filePath;

        public OrderRepository(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "table_Order.json");
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(jsonData);
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var orders = await GetAllOrdersAsync();
            return orders.FirstOrDefault(o => o.Id == id);
        }
    }
}