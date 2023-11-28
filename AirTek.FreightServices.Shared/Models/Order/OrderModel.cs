namespace AirTek.FreightServices.Shared.Models.Order
{
    public class OrderModel
    {
        public OrderModel(string orderName, int sequence, OrderDetails orderDetails)
        {
            OrderName = orderName;
            Sequence = sequence;
            OrderDetails = orderDetails;
        }

        public string OrderName { get; }
        public int Sequence { get; }
        public OrderDetails OrderDetails { get; }
    }

}
