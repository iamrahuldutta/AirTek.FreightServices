using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Main.Interfaces
{
    public interface IFlightSchedulingServiceBuilder<T, T2>
        where T : IFreightTransportWithCapacity
        where T2 : List<FreightTransportSchedule<T>>

    {
        T2 Build();
    }
}