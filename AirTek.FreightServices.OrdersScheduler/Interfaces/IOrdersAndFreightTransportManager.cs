using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.OrdersScheduler.Interfaces
{
    public interface IOrdersAndFreightTransportManager<T> where T :IFreightTransportWithCapacity
    {
        void AddOrders(List<FreightTransportSchedule<T>> schedule, OrderData orderDataModel);
    }
}