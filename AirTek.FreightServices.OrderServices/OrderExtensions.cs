using AirFreightServices.Data.Models;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.OrderServices
{
    public static class OrderExtensions
    {
        public static OrderData ToOrderData(this OrderDataModel orderDataModel)
        {
            var orders = orderDataModel.Orders.ToDictionary(
        kvp => kvp.Key,
        kvp => ConvertToOrderDetails2(kvp.Value));

            return new OrderData(orders);
        }

        public static IEnumerable<OrderModel> ToOrderDataOrderedBySequenceNumber(this OrderData dataModelList)
        {
            return dataModelList.Orders
    .Select(order => new OrderModel(order.Key, ExtractNumericValue(order.Key), order.Value)).OrderBy(order => order.Sequence).ToList();
        }

        private static int ExtractNumericValue(string orderName)
        {
            string numericPart = new string(orderName.Where(char.IsDigit).ToArray());
            return int.TryParse(numericPart, out int numericValue) ? numericValue : 0;
        }
        private static OrderDetails ConvertToOrderDetails2(OrderDetailsDataModel orderDetails)
        {
            return new OrderDetails(orderDetails.Destination);
        }
    }
}
