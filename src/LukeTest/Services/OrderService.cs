using LukeTest.Interfaces.Repositories;
using LukeTest.Interfaces.Services;
using LukeTest.Models.DAO;
using LukeTest.Models.DTO;

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

        public IEnumerable<OrderDetailDTO> GetOrderDetailsByGuid(string guid)
        {
            IEnumerable<OrderDetailDAO> orderDetails = _orderDetailRepository.GetOrderDetailsByGuidAsync(guid).Result;
            List<OrderDetailDTO> orderDetailDTOs = new();
            foreach(var orderDetail in orderDetails)
            {
                orderDetailDTOs.Add(new OrderDetailDTO
                {
                    Guid = orderDetail.Guid,
                    Username = orderDetail.Username,
                    ProductCode = orderDetail.ProductCode,
                    ProductName = orderDetail.ProductName,
                    Price = orderDetail.Price,
                    Quantity = orderDetail.Quantity,
                    IsApproved = orderDetail.IsApproved
                });
            }
            return orderDetailDTOs;
        }

        public IEnumerable<ShoppingCartDTO> GetShoppingCartInfo(string userId)
        {
            IEnumerable<OrderDetailDAO> orderDetails = _orderDetailRepository.GetOrderDetailsByUserIdAndIsApprovedAsync(userId, false).Result;
            List<ShoppingCartDTO> shoppingCartDTOs = new();
            foreach(var orderDetail in orderDetails)
            {
                shoppingCartDTOs.Add(new ShoppingCartDTO
                {
                    ProductCode = orderDetail.ProductCode,
                    ProductName = orderDetail.ProductName,
                    Price = orderDetail.Price,
                    Quantity = orderDetail.Quantity
                });
            }
            return shoppingCartDTOs;
        }

        public IEnumerable<OrderDTO> GetOrdersByUserId(string userId)
        {
            IEnumerable<OrderDAO> orders = _orderRepository.GetOrderByUserIdAsync(userId).Result;
            List<OrderDTO> orderDTOs = new();
            foreach(var order in orders)
            {
                orderDTOs.Add(new OrderDTO
                {
                    Guid = order.Guid,
                    Username = order.Username,
                    FullName = order.FullName,
                    Email = order.Email,
                    Address = order.Address,
                    Timestamp = order.Timestamp
                });
            }
            return orderDTOs;
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