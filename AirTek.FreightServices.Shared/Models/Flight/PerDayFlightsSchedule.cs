using System.Text;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record PerDayFlightsSchedule<T>() : FlightsSchedule<T> where T : Flight
    {
        public int Day { get; set; }

        public override string ToString()
        {
            StringBuilder result = new();

            foreach (var flight in Flights)
            {
                result.AppendLine($"{flight.ToString()}, day: {Day}");
            }

            return result.ToString();
        }
    }
}
