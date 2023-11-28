using AirTek.FreightServices.Shared.Interfaces;
using System.Text;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record FreightTransportSchedule<T> where T : IFreightTransportWithCapacity
    {
        public ICollection<T> FreightTransport { get; } = new List<T>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var transport in FreightTransport)
            {
                sb.AppendLine(transport.ToString());
            }

            return sb.ToString();
        }
    }
}