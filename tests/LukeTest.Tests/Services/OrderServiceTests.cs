using Castle.Core.Logging;
using LukeTest.Interfaces.Repositories;
using LukeTest.Interfaces.Services;
using LukeTest.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace LukeTest.Tests.Services
{
    public class OrderServiceTests : TestBase
    {
        private readonly ILogger<OrderService> _loggerMock;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderServiceTests()
        {
            _loggerMock = new Mock<ILogger<OrderService>>().Object;
            _productRepository = ServiceProvider.GetService<IProductRepository>();
            _orderRepository = ServiceProvider.GetService<IOrderRepository>();
            _orderDetailRepository = ServiceProvider.GetService<IOrderDetailRepository>();
        }
        
        [Fact]
        public void GetOrderDetailsByGuid_ReturnsOrderDetailDTOs()
        {
            IOrderService orderService = new OrderService(_loggerMock, _productRepository, _orderRepository, _orderDetailRepository);
            string guid = "8a80769e-e0f0-4e35-8d2a-5401716b4158";
            
            var orderDetailDTOs = orderService.GetOrderDetailsByGuid(guid);
            
            Assert.NotNull(orderDetailDTOs);
            Assert.Single(orderDetailDTOs);
            Assert.Equal(guid, orderDetailDTOs.First().Guid);
        }

        [Fact]
        public async void ApproveUserOrderDetails_ReturnTrue()
        {
            IOrderService orderService = new OrderService(_loggerMock, _productRepository, _orderRepository, _orderDetailRepository);
            string userId = "luke";
            string guid = Guid.NewGuid().ToString();
            
            var result = await orderService.ApproveUserOrderDetails(userId, guid);
            
            Assert.True(result);
        }

        [Fact]
        public void AddCartToOrder_ReturnTrue()
        {   
            Mock<OrderService> orderServiceMock = new Mock<OrderService>(_loggerMock, _productRepository, _orderRepository, _orderDetailRepository);
            IOrderService orderService = orderServiceMock.Object;
            string userId = "luke";
            string receiver = "john";
            string email = "john@gmail.com";
            string address = "taipei";

            orderServiceMock.Setup(service => service.ApproveUserOrderDetails(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            var result = orderService.AddCartToOrder(userId, receiver, email, address);
            
            Assert.True(result);
        }

        [Fact]
        public void AddCartToOrder_ReturnFalse()
        {
            Mock<OrderService> orderServiceMock = new Mock<OrderService>(_loggerMock, _productRepository, _orderRepository, _orderDetailRepository);
            IOrderService orderService = orderServiceMock.Object;
            string userId = "luke";
            string receiver = "john";
            string email = "john@gmail.com";
            string address = "taipei";

            orderServiceMock.Setup(service => service.ApproveUserOrderDetails(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);
            var result = orderService.AddCartToOrder(userId, receiver, email, address);
            
            Assert.False(result);
        }
    }
}