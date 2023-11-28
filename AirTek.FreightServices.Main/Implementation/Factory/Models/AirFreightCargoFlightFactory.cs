using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory.Models;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Main.Implementation.Factory.Models
{
    public class AirFreightCargoFlightFactory : BaseFactory, IFreightTransportWithCapacityFactory
    {
        public T CreateFreightTransport<T>(int transportNumber, int capacity, CityInformation departure, CityInformation arrival) where T : IFreightTransportWithCapacity
        {
            return (T)Activator.CreateInstance(typeof(T), transportNumber, capacity, departure, arrival);
        }
    }
}