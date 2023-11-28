using AirTek.FreightServices.FlightsServices.Interfaces.Factory;
using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.FlightsServices.Implemenation.Factory
{
    public class AirFreightFlightSchedulingServiceFactory : IFlightSchedulingServiceFactory<AirFreightCargoFlight>
    {
        public IFlightSchedulingServiceWithDisplay<AirFreightCargoFlight> CreateFlightSchedulingViaUserInputService(string userInput, IFlightScheduleFactory flightSchedulePatternFactory, IFlightSchedulerParserFromUserInput<AirFreightCargoFlight> flightDetailsParserFromUserInput)
        {
            return new AirFreightFlightSchedulingViaUserInputService(userInput, flightSchedulePatternFactory, flightDetailsParserFromUserInput);
        }
    }
}