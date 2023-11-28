using AirTek.FreightServices.OrdersScheduler.Interfaces;
using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Main.Implementation.Factory.OrderSchedulers
{
    public abstract class BaseFlightOrdersManagerFactory<T> : IBaseFlightOrdersManagerFactory<T> where T : IAddOrdersToFlight
    {
        public abstract T Create(IFreightTransportWithCapacity freightTransport, int day);
    }
}
