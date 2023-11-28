namespace AirTek.FreightServices.Shared.Models.Order
{
    public class OrderDetail
    {
        public OrderDetail(int sequence, string orderName)
        {
            Sequence = sequence;
            OrderName = orderName;
        }

        public int Sequence { get; }
        public string OrderName { get; }
    }

    public class OrdersGroupByDestination
    {
        public string Destination { get; set; }
        public IEnumerable<OrderDetail> OrdersDetails { get; set; }
    }

}
