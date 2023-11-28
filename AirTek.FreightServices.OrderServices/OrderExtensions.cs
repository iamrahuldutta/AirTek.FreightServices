using AirFreightServices.Data.Models;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirFreightServices.OrdersScheduler
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrdersGroupByDestination> ToOrdersGroupByDestination(this OrderDataModel dataModelList)
        {
            var result = dataModelList.Orders
            .Select(pair => new
            {
                OrderNumber = int.Parse(pair.Key.Split('-')[1]), // Extract numeric value
                Destination = pair.Value.Destination,
                OrderKey = pair.Key
            })
            .OrderBy(order => order.OrderNumber) // Sorting by numeric value
            .GroupBy(order => order.Destination)
            .Select(group => new OrdersGroupByDestination
            {
                Destination = group.Key,
                OrdersDetails = group.Select(order => new OrderDetail(order.OrderNumber, order.OrderKey))
            }).ToList();
            return result;
        }
    }
}
