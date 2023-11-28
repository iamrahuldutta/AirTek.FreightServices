using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public abstract record FreightTransport(int TransportNumber, CityInformation Departure, CityInformation Arrival) : IFreightTransport
    {
    }
}
