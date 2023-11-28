namespace AirTek.FreightServices.Shared.Interfaces
{
    public interface IFreightTransportWithCapacity : IFreightTransport
    {
        int Capacity { get; init; }
    }
}