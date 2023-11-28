using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces
{
    public interface IFreightTransportWithCapacity : IFreightTransport, ICapacity
    {
    }
}