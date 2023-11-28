using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces.Factory
{
    public interface IFlightFactory<T>
    {
        T CreateFlight(int flightNumber, CityInformation destination, CityInformation arrival);

        CityInformation CreateCityInformation(string name, string abbreviation);
    }
}
