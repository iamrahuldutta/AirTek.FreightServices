namespace AirTek.FreightServices.Shared.Interfaces
{
    public interface IAirFreightCargoFlight : IFlight
    {
        int Capacity { get; init; }
    }
}