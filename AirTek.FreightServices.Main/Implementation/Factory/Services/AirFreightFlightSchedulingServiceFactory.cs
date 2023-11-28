using AirTek.FreightServices.FlightsServices.Implemenation.Services;
using AirTek.FreightServices.FlightsServices.Interfaces.Factory;
using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory.Models;

namespace AirTek.FreightServices.Main.Implementation.Factory.Services
{
    public class AirFreightFlightSchedulingServiceFactory : IFreightTransportSchedulingServiceFactory
    {
        public IFreightTransportSchedulingService<T> CreateFreightTransportScheduleViaUserInputService<T>(string userInput, IFreightTransportScheduleFactory flightSchedulePatternFactory, IFreightTransportSchedulerParserFromUserInput flightDetailsParserFromUserInput) where T : IFreightTransportWithCapacity
        {
            return new FreightTransportSchedulingViaUserInputService<T>(userInput, flightSchedulePatternFactory, flightDetailsParserFromUserInput);
        }
    }
}