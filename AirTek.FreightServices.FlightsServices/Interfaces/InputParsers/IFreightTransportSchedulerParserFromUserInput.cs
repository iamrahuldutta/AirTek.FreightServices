using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.FlightsServices.Interfaces.InputParsers
{
    public interface IFreightTransportSchedulerParserFromUserInput
    {
        int ParseDayValue(string userInput);
        T ParseTransportDetailsFromUserInput<T>(string userInput) where T : IFreightTransportWithCapacity;
    }
}
