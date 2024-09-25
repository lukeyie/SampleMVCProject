using LukeTest.Interfaces.Repositories;
using LukeTest.Interfaces.Services;
using LukeTest.Models.DAO;

namespace LukeTest.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        
        public OrderService(ILogger<OrderService> logger, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetailDAO> GetOrderDetailsByGuid(string guid)
        {
            return _orderDetailRepository.GetOrderDetailsByGuidAsync(guid).Result;
        }

        public IEnumerable<OrderDetailDAO> GetOrderDetailsByUserId(string userId, bool IsApproved)
        {
            return _orderDetailRepository.GetOrderDetailsByUserIdAndIsApprovedAsync(userId, IsApproved).Result;
        }

        public IEnumerable<OrderDAO> GetOrdersByUserId(string userId)
        {
            return _orderRepository.GetOrderByUserIdAsync(userId).Result;
        }

        public bool AddCartToOrder(string userId, string receiver, string email, string address)
        {
            string orderGuid = Guid.NewGuid().ToString();
            if(!ApproveUserOrderDetails(userId, orderGuid).Result)
            {
                return false;
            }
            
            OrderDAO order = new OrderDAO
            {
                Guid = orderGuid, 
                Username = userId,
                FullName = receiver,
                Email = email,
                Address = address,
                Timestamp = DateTime.Now.ToString()
            };
            return _orderRepository.CreateOrder(order);
        }

        public async Task<bool> ApproveUserOrderDetails(string userId, string orderGuid)
        {
            IEnumerable<OrderDetailDAO> orderDetails = await _orderDetailRepository.GetAllOrderDetailsAsync();
            IEnumerable<OrderDetailDAO> userOrderDetails = orderDetails.Where(od => od.Username == userId && od.IsApproved == "否");
            foreach(var orderDetail in userOrderDetails)
            {
                orderDetail.IsApproved = "是";
                orderDetail.Guid = orderGuid;
            }
            _orderDetailRepository.UpdateOrderDetails(orderDetails);
            return true;
        }
    }
}