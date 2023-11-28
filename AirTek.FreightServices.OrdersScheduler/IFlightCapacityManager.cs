using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models;
using AirTek.FreightServices.Shared.Models.Flight;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.OrdersScheduler
{
    public interface IFreightTransportCapacityManager
    {
        int RemainingCapacity { get; }
        bool IsFullyOccupied();
    }
    public interface IAddOrdersToFreightTransport<T, T2> where T : IFreightTransportWithCapacity
        where T2 : IFreightTransportScheduleList<T>
    {
        IEnumerable<FlightAndOrdersMap> AssignedFlightAndOrdersMap { get; }
        IEnumerable<FlightAndOrdersMap> UnassignedFlightAndOrdersMap { get; }
        void AddOrdersToFreightTransport(OrderData orderDataModel, T2 schedule);
    }

    public class AddOrdersToFreightTransportPerDay<T, T2> : IAddOrdersToFreightTransport<T, T2> where T : IFreightTransportWithCapacity
        where T2 : IFreightTransportScheduleList<T>
    {
        public IEnumerable<FlightAndOrdersMap> AssignedFlightAndOrdersMap => throw new NotImplementedException();

        public IEnumerable<FlightAndOrdersMap> UnassignedFlightAndOrdersMap => throw new NotImplementedException();

        public void AddOrdersToFreightTransport(OrderData orderDataModel, T2 schedule)
        {
            throw new NotImplementedException();
        }
    }
}
