using AirTek.FreightServices.Shared.Models.Order;

namespace AirFreightServices.OrdersScheduler.Interfaces
{
    public interface IOrderDataService
    {
        Task<OrderData> GetOrders();
    }
}
