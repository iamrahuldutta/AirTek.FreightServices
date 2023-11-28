namespace AirTek.FreightServices.FlightsServices.Interfaces.InputParsers
{
    public interface IFlightSchedulerParserFromUserInput<T>
    {
        int ParseDayValue(string userInput);
        T ParseFlightDetailsFromUserInput(string userInput);
    }
}
