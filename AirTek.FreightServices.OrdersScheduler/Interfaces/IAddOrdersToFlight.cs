using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.OrdersScheduler.Interfaces
{
    public interface IAddOrdersToFlight
    {
        IEnumerable<OrderModel> Orders { get; }
        IFreightTransportWithCapacity Freight { get; }
        int RemainingCapacity { get; }
        bool CanAccomodate { get; }
        bool AddOrder(OrderModel orderName);
    }
}
