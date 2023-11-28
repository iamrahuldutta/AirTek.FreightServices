using AirTek.FreightServices.FlightsServices.Implemenation.InputParsers;
using AirTek.FreightServices.FlightsServices.Implemenation.Internal;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Main.Implementation.Factory.Models;
using AirTek.FreightServices.Main.Implementation.Factory.Services;
using AirTek.FreightServices.Main.Interfaces;
using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Main.Implementation
{
    public class AirFreightCargoFlightBuilder<T> : IFlightSchedulingServiceBuilder<T, IFreightTransportSchedulingService<T>> where T: IFreightTransportWithCapacity
    {
        private string _userInput;

        public IFreightTransportSchedulingService<T> Build()
        {
            var flightDataService = new FlightStaticDataService();
            var flightSchedulerFactory = new AirFreightFlightSchedulingServiceFactory();
            var flightSchedulePatternFactory = new PerDayFreightTransportScheduleFactory();
            var flightFactory = new AirFreightCargoFlightFactory();
            var flightDetailsParser = new AirFreightFlightSchedulerParserFromUserInput(flightFactory, flightDataService);
            return flightSchedulerFactory.CreateFreightTransportScheduleViaUserInputService<T>(_userInput, flightSchedulePatternFactory, flightDetailsParser);
        }

        public AirFreightCargoFlightBuilder<T> WithUserInput(string userInput)
        {
            _userInput = userInput;
            return this;
        }

    }
}