using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory.Models;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Main.Implementation.Factory.Models
{
    public class PerDayFreightTransportScheduleFactory : IFreightTransportScheduleFactory
    {
        public FreightTransportSchedule<T> CreateFreightTransportSchedule<T>() where T : IFreightTransportWithCapacity
        {
            return new PerDayFreightTransportSchedule<T>();
        }
    }
}
