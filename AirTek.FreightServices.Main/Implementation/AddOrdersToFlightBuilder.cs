using AirTek.FreightServices.Main.Implementation.Factory.OrderSchedulers;
using AirTek.FreightServices.Main.Interfaces;
using AirTek.FreightServices.OrdersScheduler.Implementation;
using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;
using AirTek.FreightServices.Shared.Models.Order;

namespace AirTek.FreightServices.Main.Implementation
{
    internal class AddOrdersToFlightBuilder<T> : IAddOrdersToFlightBuilder where T : IFreightTransportWithCapacity
    {
        private List<FreightTransportSchedule<T>> _schedule;
        private OrderData _orderDataModel;
        public AddOrdersToFlightBuilder<T> WithSchedule(List<FreightTransportSchedule<T>> freightTransportSchedules)
        {
            _schedule = freightTransportSchedules;
            return this;
        }

        public AddOrdersToFlightBuilder<T> WithOrders(OrderData orderDataModel)
        {
            _orderDataModel = orderDataModel;
            return this;
        }

        public void Build()
        {
            var ordersAndFreightManager = new OrdersAndFreightTransportManager<FlightOrdersManager, T>(new AddOrdersToFlightFactory());
            ordersAndFreightManager.AddOrders(_schedule, _orderDataModel);
            Console.WriteLine(ordersAndFreightManager.ToString());
        }
    }
}
