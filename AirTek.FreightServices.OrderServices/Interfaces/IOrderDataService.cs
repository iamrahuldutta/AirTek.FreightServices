using AirTek.FreightServices.Shared.Models.Order;

namespace AirFreightServices.OrdersScheduler.Interfaces
{
    public interface IOrderDataService
    {
        Task<IEnumerable<OrdersGroupByDestination>> GetOrders();
    }
}
