using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.FlightsServices.Interfaces.Services
{
    public interface IFreightTransportSchedulingService<T> : IBaseService where T : IFreightTransportWithCapacity
    {
        List<FreightTransportSchedule<T>> CreateFlightsScheduleList();
    }
}
