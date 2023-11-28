using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Implementation.Factory
{
    public abstract class FlightFactory<T> : IFlightFactory<T> where T : IFlight
    {
        public CityInformation CreateCityInformation(string name, string abbreviation)
        {
            return new CityInformation(name, abbreviation);
        }

        public T CreateFlight(int flightNumber, CityInformation destination, CityInformation arrival)
        {
            return (T)Activator.CreateInstance(typeof(T), flightNumber, destination, arrival);
        }
    }
}
