using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.OrdersScheduler.Interfaces
{
    public interface IBaseFlightOrdersManagerFactory<T> where T : IAddOrdersToFlight
    {
        T Create(IFreightTransportWithCapacity freightTransport, int day);
    }
}