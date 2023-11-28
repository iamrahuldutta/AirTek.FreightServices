using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces
{
    public interface IFreightTransport
    {
        int TransportNumber { get; init; }
        CityInformation Arrival { get; init; }
        CityInformation Departure { get; init; }
    }
}