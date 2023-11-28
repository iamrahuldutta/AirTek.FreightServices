using AirFreightServices.OrdersScheduler.Interfaces;
using AirTek.FreightServices.DataServices.Implementation;
using AirTek.FreightServices.DataServices.Interfaces;
using AirTek.FreightServices.Main.Interfaces;
using AirTek.FreightServices.OrderServices.Implementation;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.Main.Implementation
{
    internal class OrdersLoaderBuilder : IOrderLoaderBuilder<OrderData>
    {
        
        private string _filePath;

        

        public OrdersLoaderBuilder WithJsonFilePath(string filePath)
        {
            _filePath = filePath;
            return this;
        }

        public async Task<OrderData> Build()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "coding-assigment-orders.json");
            IOrdersLoader ordersLoader = new OrdersLoaderFromJsonFile(filePath);
            IOrderDataService orderLoader = new OrderDataService(ordersLoader);
            return await orderLoader.GetOrders();
        }
    }
}
