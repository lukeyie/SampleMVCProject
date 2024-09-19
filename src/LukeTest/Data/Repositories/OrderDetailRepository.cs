using LukeTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace LukeTest.Data.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly string _filePath;

        public OrderDetailRepository(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "table_OrderDetail.json");
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var orderDetails = JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(jsonData);
            return orderDetails;
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
        {
            var orderDetails = await GetAllOrderDetailsAsync();
            return orderDetails.FirstOrDefault(od => od.Id == id);
        }
    }
}