using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces.Factory
{
    public interface IAirFreightCargoFlightFactory : IFlightFactory<AirFreightCargoFlight>
    {
        AirFreightCargoFlight CreateAirFreightCargoFlight(int flightNumber, int capacity, CityInformation departure, CityInformation arrival);
    }
}
