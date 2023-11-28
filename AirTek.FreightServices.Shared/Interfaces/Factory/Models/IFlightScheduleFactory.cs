using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces.Factory.Models
{
    public interface IFreightTransportScheduleFactory
    {
        FreightTransportSchedule<T> CreateFreightTransportSchedule<T>() where T : IFreightTransportWithCapacity;
    }
}
