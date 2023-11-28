using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces.Factory.Models
{
    public interface IFreightTransportWithCapacityFactory : ICityInformationFactory
    {
        T CreateFreightTransport<T>(int transportNumber, int capacity, CityInformation departure, CityInformation arrival) where T : IFreightTransportWithCapacity;
    }
}
