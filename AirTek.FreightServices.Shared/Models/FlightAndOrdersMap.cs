using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.Shared.Models
{
    public class FlightAndOrdersMap
    {
        public IFreightTransportWithCapacity Freight { get; set; }
        public IEnumerable<OrderDetail> Orders { get; set; }
    }
}
