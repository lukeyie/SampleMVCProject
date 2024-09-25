using LukeTest.Interfaces.Repositories;
using LukeTest.Models.DAO;
using Newtonsoft.Json;

namespace LukeTest.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly string _filePath;

        public OrderDetailRepository(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "table_OrderDetail.json");
        }

        public async Task<IEnumerable<OrderDetailDAO>> GetAllOrderDetailsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            var orderDetails = JsonConvert.DeserializeObject<IEnumerable<OrderDetailDAO>>(jsonData) ?? new List<OrderDetailDAO>();
            return orderDetails;
        }

        public async Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByGuidAsync(string guid)
        {
            IEnumerable<OrderDetailDAO> orderDetails = await GetAllOrderDetailsAsync();
            return orderDetails.Where(od => od.Guid == guid);
        }

        public async Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByUserIdAndIsApprovedAsync(string userId, bool isApproved)
        {
            IEnumerable<OrderDetailDAO> orderDetails = await GetAllOrderDetailsAsync();
            string isApprovedStr = isApproved ? "是" : "否";
            return orderDetails.Where(od => od.Username == userId && od.IsApproved == isApprovedStr);
        }

        public async Task<bool> UpdateOrderDetails(IEnumerable<OrderDetailDAO> orderDetails)
        {
            var jsonData = JsonConvert.SerializeObject(orderDetails, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
            return true;
        }
    }
}