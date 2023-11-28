using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Implementation.Factory
{
    public class AirFreightCargoFlightFactory : FlightFactory<AirFreightCargoFlight>, IAirFreightCargoFlightFactory
    {
        public AirFreightCargoFlight CreateAirFreightCargoFlight(int flightNumber, int capacity, CityInformation departure, CityInformation arrival)
        {
            return new AirFreightCargoFlight(flightNumber, capacity, departure, arrival);
        }
    }
}
