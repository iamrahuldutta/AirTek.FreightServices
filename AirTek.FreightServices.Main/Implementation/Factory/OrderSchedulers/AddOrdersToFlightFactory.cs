using AirTek.FreightServices.OrdersScheduler.Implementation;
using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Main.Implementation.Factory.OrderSchedulers
{
    public class AddOrdersToFlightFactory : BaseFlightOrdersManagerFactory<FlightOrdersManager>
    {
        public override FlightOrdersManager Create(IFreightTransportWithCapacity freightTransport, int day)
        {
            return new FlightOrdersManager(freightTransport, day);
        }
    }
}
