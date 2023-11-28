using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record AirFreightFlight(int FlightNumber, int Capacity, CityInformation Departure, CityInformation Arrival)
        : FreightTransport(FlightNumber, Departure, Arrival), IFreightTransportWithCapacity
    {
        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {Departure.Abbreviation}, arrival: {Arrival.Abbreviation}";
        }
    }
}
