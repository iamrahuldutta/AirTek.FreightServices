using AirTek.FreightServices.FlightsServices.Implemenation.Factory;
using AirTek.FreightServices.FlightsServices.Implemenation.InputParsers;
using AirTek.FreightServices.FlightsServices.Implemenation.Internal;
using AirTek.FreightServices.FlightsServices.Interfaces.Internal;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Main.Interfaces;
using AirTek.FreightServices.Shared.Implementation.Factory;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Main.Implementation
{
    public class AirFreightCargoFlightBuilder : IFlightSchedulingServiceBuilder<IFlightSchedulingServiceWithDisplay<AirFreightCargoFlight>, AirFreightCargoFlight>
    {
        private string _userInput;

        public AirFreightCargoFlightBuilder WithUserInput(string userInput)
        {
            _userInput = userInput;
            return this;
        }

        public IFlightSchedulingServiceWithDisplay<AirFreightCargoFlight> Build()
        {
            IFlightDataService flightDataService = new FlightStaticDataService();
            var flightSchedulerFactory = new AirFreightFlightSchedulingServiceFactory();
            var flightSchedulePatternFactory = new PerDayFlightsScheduleFactory();
            var flightFactory = new AirFreightCargoFlightFactory();
            var flightDetailsParser = new AirFreightFlightSchedulerParserFromUserInput(flightFactory, flightDataService);
            return flightSchedulerFactory.CreateFlightSchedulingViaUserInputService(_userInput, flightSchedulePatternFactory, flightDetailsParser);
        }
    }
}