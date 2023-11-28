using AirTek.FreightServices.FlightsServices.Implemenation.InputParsers;
using AirTek.FreightServices.FlightsServices.Implemenation.Internal;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Main.Implementation.Factory.Models;
using AirTek.FreightServices.Main.Implementation.Factory.Services;
using AirTek.FreightServices.Main.Interfaces;
using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Main.Implementation
{
    public class AirFreightCargoFlightBuilder<T> : IFlightSchedulingServiceBuilder<T, List<FreightTransportSchedule<T>>> where T : IFreightTransportWithCapacity
    {
        private string _userInput;

        public List<FreightTransportSchedule<T>> Build()
        {
            var flightDataService = new FlightStaticDataService();
            var flightSchedulerFactory = new AirFreightFlightSchedulingServiceFactory();
            var flightSchedulePatternFactory = new PerDayFreightTransportScheduleFactory();
            var flightFactory = new AirFreightCargoFlightFactory();
            var flightDetailsParser = new AirFreightFlightSchedulerParserFromUserInput(flightFactory, flightDataService);
            var freightSchedulerService = flightSchedulerFactory.CreateFreightTransportScheduleViaUserInputService<T>(_userInput, flightSchedulePatternFactory, flightDetailsParser);
            var flightsScheduleList = freightSchedulerService.CreateFlightsScheduleList();
            Console.WriteLine("Flights Schedule Result:");
            Console.WriteLine(freightSchedulerService.GetDisplayString());
            return flightsScheduleList;
        }

        public AirFreightCargoFlightBuilder<T> WithUserInput(string userInput)
        {
            _userInput = userInput;
            return this;
        }

    }
}