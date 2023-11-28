using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Main.Interfaces
{
    public interface IFlightSchedulingServiceBuilder<T, T2> where T : IFlightSchedulingServiceWithDisplay<T2>
              where T2 : IFlight
    {
        T Build();
    }
}