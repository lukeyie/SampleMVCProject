using LukeTest.Models;
using Newtonsoft.Json;

namespace LukeTest.Data.Repositories
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

        public async Task<IEnumerable<OrderDetailDAO>> GetOrderDetailsByUserIdAndIsApprovedAsync(string userId, bool isApproved)
        {
            IEnumerable<OrderDetailDAO> orderDetails = await GetAllOrderDetailsAsync();
            string isApprovedStr = isApproved ? "是" : "否";
            return orderDetails.Where(od => od.Username == userId && od.IsApproved == isApprovedStr);
        }

        public async Task<bool> ApproveUserOrderDetails(string userId, string orderGuid)
        {
            IEnumerable<OrderDetailDAO> orderDetails = await GetAllOrderDetailsAsync();
            IEnumerable<OrderDetailDAO> userOrderDetails = orderDetails.Where(od => od.Username == userId);
            foreach(var orderDetail in userOrderDetails)
            {
                orderDetail.IsApproved = "是";
                orderDetail.Guid = orderGuid;
            }
            var jsonData = JsonConvert.SerializeObject(orderDetails);
            File.WriteAllText(_filePath, jsonData);
            return true;
        }
    }
}