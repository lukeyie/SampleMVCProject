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
        private readonly IOrderDetailRepository _orderDetailRepository;
        
        public OrderService(ILogger<OrderService> logger, IOrderDetailRepository orderDetailRepository)
        {
            _logger = logger;
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetailDAO> GetOrderDetailByUserId(string userId, bool IsApproved)
        {
            return _orderDetailRepository.GetOrderDetailsByUserIdAndIsApprovedAsync(userId, IsApproved).Result;
        }
    }
}