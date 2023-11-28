using AirFreightServices.OrdersScheduler;
using AirFreightServices.OrdersScheduler.Interfaces;
using AirTek.FreightServices.DataServices.Interfaces;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.OrderServices.Implementation
{
    public class OrderDataService : IOrderDataService
    {
        private readonly IOrdersLoader _ordersLoader;

        public OrderDataService(IOrdersLoader ordersLoader)
        {
            _ordersLoader = ordersLoader;
        }
        public async Task<IEnumerable<OrdersGroupByDestination>> GetOrders()
        {
            return (await _ordersLoader.LoadOrders()).ToOrdersGroupByDestination();
        }
    }
}
