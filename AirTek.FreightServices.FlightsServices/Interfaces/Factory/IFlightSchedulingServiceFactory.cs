using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.FlightsServices.Interfaces.Factory
{
    public interface IFlightSchedulingServiceFactory<T> where T : IFlight
    {
        IFlightSchedulingServiceWithDisplay<T> CreateFlightSchedulingViaUserInputService(string userInput, IFlightScheduleFactory flightSchedulePatternFactory, IFlightSchedulerParserFromUserInput<T> flightDetailsParserFromUserInput);
    }
}