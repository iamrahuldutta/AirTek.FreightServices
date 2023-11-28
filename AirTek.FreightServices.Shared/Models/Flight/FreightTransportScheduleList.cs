using AirTek.FreightServices.Shared.Interfaces;
using System.Text;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record FreightTransportScheduleList<T>(ICollection<FreightTransportSchedule<T>> FreightTransportList) : IFreightTransportScheduleList<T> where T : IFreightTransportWithCapacity
    {
        public FreightTransportScheduleList() : this(new List<FreightTransportSchedule<T>>())
        {
        }

        public void AddPerDayFlightsSchedule(FreightTransportSchedule<T> freightTransport)
        {
            FreightTransportList.Add(freightTransport);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var transport in FreightTransportList)
            {
                sb.AppendLine(transport.ToString());
            }

            return sb.ToString();
        }
    }
}
