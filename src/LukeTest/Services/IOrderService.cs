using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LukeTest.Models;

namespace LukeTest.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDetailDAO> GetOrderDetailByUserId(string userId, bool IsApproved);
        bool AddCartToOrder(string userId, string receiver, string email, string address);
    }
}