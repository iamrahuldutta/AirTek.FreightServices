using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory.Models;

namespace AirTek.FreightServices.Main.Interfaces.Factory.Services
{
    public interface IFreightTransportSchedulingServiceFactory
    {
        IFreightTransportSchedulingService<T> CreateFreightTransportScheduleViaUserInputService<T>(string userInput, IFreightTransportScheduleFactory flightSchedulePatternFactory, IFreightTransportSchedulerParserFromUserInput flightDetailsParserFromUserInput) where T : IFreightTransportWithCapacity;
    }
}