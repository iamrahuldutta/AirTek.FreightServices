using AirFreightServices.Data.Models;

namespace AirTek.FreightServices.DataServices.Interfaces
{
    public interface IOrdersLoader
    {
        Task<OrderDataModel> LoadOrders();
    }
}
