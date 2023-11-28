namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record AirFreightCargoFlight(int FlightNumber, int Capacity, CityInformation Departure, CityInformation Arrival)
        : Flight(FlightNumber, Departure, Arrival)
    {
        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {Departure.Abbreviation}, arrival: {Arrival.Abbreviation}";
        }
    }
}
