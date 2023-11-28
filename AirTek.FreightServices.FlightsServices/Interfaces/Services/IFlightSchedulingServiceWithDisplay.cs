using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.FlightsServices.Interfaces.Services
{
    public interface IFlightSchedulingServiceWithDisplay<T> : IFlightSchedulingService<T> where T : IFlight
    {
        string GetDisplayString();
    }
}
