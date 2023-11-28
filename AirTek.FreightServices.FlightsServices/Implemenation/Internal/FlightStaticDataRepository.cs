using AirTek.FreightServices.FlightsServices.Interfaces.Internal;

namespace AirTek.FreightServices.FlightsServices.Implemenation.Internal
{
    public class FlightStaticDataService : IFlightDataService
    {
        public int GetDefaultFlightCapacity()
        {
            return 20;
        }
    }
}
