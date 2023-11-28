using AirTek.FreightServices.Shared.Interfaces;
using System.Text;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record PerDayFreightTransportSchedule<T>() : FreightTransportSchedule<T> where T : IFreightTransportWithCapacity
    {
        public int Day { get; set; }

        public override string ToString()
        {
            StringBuilder result = new();

            foreach (var transport in FreightTransport)
            {
                result.AppendLine($"{transport.ToString()}, day: {Day}");
            }

            return result.ToString();
        }
    }
}
