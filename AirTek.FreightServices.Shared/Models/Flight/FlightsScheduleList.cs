using AirTek.FreightServices.Shared.Interfaces;
using System.Text;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record FlightsScheduleList<T>(ICollection<FlightsSchedule<T>> FlightsSchedule) where T : IFlight
    {
        public FlightsScheduleList() : this(new List<FlightsSchedule<T>>())
        {
        }

        public void AddPerDayFlightsSchedule(FlightsSchedule<T> flightSchedule)
        {
            FlightsSchedule.Add(flightSchedule);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var flightSchedule in FlightsSchedule)
            {
                sb.AppendLine(flightSchedule.ToString());
            }

            return sb.ToString();
        }
    }
}
