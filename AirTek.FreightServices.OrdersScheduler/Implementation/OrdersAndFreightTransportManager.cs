using AirTek.FreightServices.Shared.Models.Flight;
using AirTek.FreightServices.Shared.Models.Order;
using AirTek.FreightServices.OrderServices;
using AirTek.FreightServices.OrdersScheduler.Interfaces;
using AirTek.FreightServices.Shared.Interfaces;
using System.Text;

namespace AirTek.FreightServices.OrdersScheduler.Implementation
{
    public class OrdersAndFreightTransportManager<T, T2> : IOrdersAndFreightTransportManager<T2> where T : IAddOrdersToFlight
        where T2 : IFreightTransportWithCapacity
    {
        private readonly IBaseFlightOrdersManagerFactory<T> _flightOrdersManagerFactory;
        private List<OrderModel> _unAssignedOrders;
        private List<T> _flightOrderManagers;

        public OrdersAndFreightTransportManager(IBaseFlightOrdersManagerFactory<T> flightOrdersManagerFactory)
        {
            _unAssignedOrders = new List<OrderModel>();
            _flightOrderManagers = new List<T>();
            _flightOrdersManagerFactory = flightOrdersManagerFactory;
        }

        public void AddOrders(List<FreightTransportSchedule<T2>> schedule, OrderData orderDataModel)
        {
            InitializeFreightOrderManager(schedule);

            var ordersInSequence = orderDataModel.ToOrderDataOrderedBySequenceNumber();

            foreach (var item in ordersInSequence)
            {
                var flightOrderManager = _flightOrderManagers.Where(x => x.Freight.Arrival.Abbreviation.Equals(item.OrderDetails.Arrival)
                && x.CanAccomodate).OrderBy(x => x.Freight.TransportNumber).FirstOrDefault();

                if (flightOrderManager == null)
                {
                    _unAssignedOrders.Add(item);
                }
                else
                {
                    var isAdded = flightOrderManager.AddOrder(item);

                    if (!isAdded)
                    {
                        _unAssignedOrders.Add(item);
                    }
                }
            }
        }

        private void InitializeFreightOrderManager(List<FreightTransportSchedule<T2>> schedule)
        {
            var collection = schedule.SelectMany(schedule => schedule.FreightTransport.Select(x => _flightOrdersManagerFactory.Create(x, (schedule is PerDayFreightTransportSchedule<T2> perDay) ? perDay.Day : 0)));

            foreach (var item in collection)
            {
                _flightOrderManagers.Add(item);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var flightManager in _flightOrderManagers)
            {
                sb.AppendLine(flightManager.ToString());
            }

            if (_unAssignedOrders.Any())
            {
                sb.AppendLine();
                sb.AppendLine("Unassigned orders are as follows:");
            }

            foreach (var order in _unAssignedOrders)
            {
                sb.AppendLine($"order: {order.OrderName}, flightNumber: not scheduled");
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
