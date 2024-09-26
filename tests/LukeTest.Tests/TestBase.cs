using LukeTest.Interfaces.Repositories;
using LukeTest.Tests.Mocks.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace LukeTest.Tests
{
    public class TestBase
    {
        protected IServiceProvider ServiceProvider { get; private set; }

        public TestBase()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register your services and mocks here
            // var mockProductRepostiory = new Mock<IProductRepository>();

            // Setup mock behavior if needed
            // mockProductService.Setup(...);

            services
                .AddSingleton<IMemberRepository, MockMemberRepository>()
                .AddSingleton<IOrderDetailRepository, MockOrderDetailRepository>()
                .AddSingleton<IOrderRepository, MockOrderRepository>()
                .AddSingleton<IProductRepository, MockProductRepository>();
    
            // Register other services if needed
            // services.AddTransient<SomeOtherService>();
        }
    }
}