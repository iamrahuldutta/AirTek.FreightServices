using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces.Factory
{
    public interface IFlightScheduleFactory
    {
        FlightsSchedule<T> CreateFlightsSchedule<T>() where T : Flight;
    }
}
