using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces
{
    public interface IFlight
    {
        CityInformation Arrival { get; init; }
        CityInformation Departure { get; init; }
        int FlightNumber { get; init; }
    }
}