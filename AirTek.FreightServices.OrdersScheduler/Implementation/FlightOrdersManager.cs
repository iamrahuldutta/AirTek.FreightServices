using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Order;
using System.Text;
using AirTek.FreightServices.OrdersScheduler.Interfaces;

namespace AirTek.FreightServices.OrdersScheduler.Implementation
{
    public class FlightOrdersManager : IAddOrdersToFlight
    {
        private readonly IFreightTransportWithCapacity _flight;
        private readonly int _day;
        private readonly List<OrderModel> _orders = new();
        public FlightOrdersManager(IFreightTransportWithCapacity flight, int day)
        {
            _flight = flight;
            RemainingCapacity = flight.Capacity;
            _day = day;
        }
        public int RemainingCapacity { get; private set; }

        public IFreightTransportWithCapacity Freight => _flight;

        public bool CanAccomodate => RemainingCapacity > 0;

        public IEnumerable<OrderModel> Orders => _orders;

        public bool AddOrder(OrderModel orderDetail)
        {
            if (CanAccomodate)
            {
                _orders.Add(orderDetail);
                RemainingCapacity--;
                return true;
            }
            return false;
        }

        public bool Occupy()
        {
            if (CanAccomodate)
            {
                RemainingCapacity++;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var order in _orders)
            {
                sb.AppendLine($"order: {order.OrderName}, flightNumber: {_flight.TransportNumber}, departure: {_flight.Departure.Name}, arrival: {_flight.Arrival.Name}, day: {_day}");
            }

            return sb.ToString();
        }
    }









    //public class FlightOrdersManager : IFlightOrdersManager
    //{
    //    private readonly IFreightTransportWithCapacity _flight;
    //    private readonly List<AirTek.FreightServices.Shared.Models.Order.OrderDetails> _orders = new List<AirTek.FreightServices.Shared.Models.Order.OrderDetails>();
    //    public FlightOrdersManager(IFreightTransportWithCapacity flight)
    //    {
    //        _flight = flight;
    //        RemainingCapacity = flight.Capacity;
    //    }

    //    public int RemainingCapacity { get; private set; }

    //    public IFreightTransportWithCapacity Freight => _flight;

    //    public bool CanAccomodate => RemainingCapacity > 0;

    //    public IEnumerable<AirTek.FreightServices.Shared.Models.Order.OrderDetails> Orders => _orders;

    //    public bool AddOrder(AirTek.FreightServices.Shared.Models.Order.OrderDetails orderDetail)
    //    {
    //        if (CanAccomodate)
    //        {
    //            _orders.Add(orderDetail);
    //            RemainingCapacity--;
    //            return true;
    //        }
    //        else
    //        {

    //        }
    //        return false;
    //    }

    //    public bool Occupy()
    //    {
    //        if (CanAccomodate)
    //        {
    //            RemainingCapacity++;
    //            return true;
    //        }
    //        return false;
    //    }
    //}

    //public class AddOrdersToFlight
    //{
    //    //private List<IFlightOrdersManager> flightOrderManagers = new List<IFlightOrdersManager>();
    //    private List<AirTek.FreightServices.Shared.Models.Order.OrderDetails> _unAssignedOrders;
    //    private List<FlightOrdersManager> flightOrderManagers;

    //    public AddOrdersToFlight(List<FreightTransportSchedule<AirFreightFlight>> schedule)
    //    {
    //        _unAssignedOrders = new List<OrderDetails>();
    //        flightOrderManagers = new List<FlightOrdersManager>();

    //        IEnumerable<FlightOrdersManager> collection = schedule.SelectMany(
    //                    schedule => schedule.FreightTransport.Select(x => new FlightOrdersManager(x)));

    //        foreach (var item in collection)
    //        {
    //            flightOrderManagers.Add(item);
    //        }

    //        //flightOrderManagers.AddRange(collection);
    //    }

    //    public void AddOrders(OrderData orderDataModel)
    //    {

    //        var ordersInSequence = orderDataModel.ToOrderDataOrderedBySequenceNumber();

    //        var orders = orderDataModel.Orders.Take(5);

    //        foreach (var item in ordersInSequence)
    //        {
    //            var flightOrderManager = flightOrderManagers.Where(x => x.Freight.Arrival.Abbreviation.Equals(item.OrderDetails.Arrival)
    //            && x.CanAccomodate).OrderBy(x => x.Freight.TransportNumber).FirstOrDefault();

    //            if (flightOrderManager == null)
    //            {
    //                _unAssignedOrders.Add(item.OrderDetails);
    //            }
    //            else
    //            {
    //                var isAdded = flightOrderManager.AddOrder(item.OrderDetails);

    //                if(!isAdded)
    //                {
    //                    _unAssignedOrders.Add(item.OrderDetails);
    //                }
    //            }
    //        }
    //    }

    //    private IFlightOrdersManager GetFreightsOrderDataManager(string to)
    //    {
    //        var freight = flightOrderManagers.Where(x => x.Freight.Arrival.Abbreviation.Equals(to) && x.CanAccomodate).OrderBy(x => x.Freight.TransportNumber).FirstOrDefault();
    //        //if (freight != null)
    //        //{
    //        //    Freights.Remove(freight);
    //        //}
    //        return freight;

    //    }

    //    private IFlightOrdersManager GetFlightOrderManager()
    //    {
    //        return null;
    //    }
    //}

}
