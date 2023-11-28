using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.FlightsServices.Interfaces.Services
{
    public interface IFlightSchedulingService<T> where T : IFlight
    {
        FlightsScheduleList<T> CreateFlightsScheduleList();
    }
}
