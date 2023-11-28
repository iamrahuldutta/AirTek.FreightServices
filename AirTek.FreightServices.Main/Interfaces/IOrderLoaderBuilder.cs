using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.Main.Interfaces
{
    internal interface IOrderLoaderBuilder<T> where T : OrderData
    {
        Task<T> Build();
    }
}
