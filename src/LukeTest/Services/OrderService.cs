using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LukeTest.Data.Repositories;
using LukeTest.Models;

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

        public IEnumerable<OrderDetailDAO> GetOrderDetailByUserId(string userId, bool IsApproved)
        {
            return _orderDetailRepository.GetOrderDetailsByUserIdAndIsApprovedAsync(userId, IsApproved).Result;
        }

        public bool AddCartToOrder(string userId, string receiver, string email, string address)
        {
            string orderGuid = Guid.NewGuid().ToString();
            if(!_orderDetailRepository.ApproveUserOrderDetails(userId, orderGuid).Result)
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
    }
}