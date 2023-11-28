using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public interface IFreightTransportScheduleList<T> where T : IFreightTransportWithCapacity
    {
        ICollection<FreightTransportSchedule<T>> FreightTransportList { get; init; }

        void AddPerDayFlightsSchedule(FreightTransportSchedule<T> freightTransport);
    }
}