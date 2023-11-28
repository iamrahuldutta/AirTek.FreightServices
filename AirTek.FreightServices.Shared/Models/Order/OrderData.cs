namespace AirTek.FreightServices.Shared.Models.Order
{
    public record OrderData(Dictionary<string, OrderDetails> Orders);
}
