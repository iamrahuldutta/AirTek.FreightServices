using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Main.Interfaces
{
    public interface IFlightSchedulingServiceBuilder<T, T2>
        where T : IFreightTransportWithCapacity
        where T2 : IFreightTransportSchedulingService<T>

    {
        T2 Build();
    }
}