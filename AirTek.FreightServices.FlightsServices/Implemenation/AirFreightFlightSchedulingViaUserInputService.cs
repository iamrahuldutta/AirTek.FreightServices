using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.FlightsServices.Implemenation
{
    public class AirFreightFlightSchedulingViaUserInputService : IFlightSchedulingService<AirFreightCargoFlight>, IFlightSchedulingServiceWithDisplay<AirFreightCargoFlight>
    {
        private readonly string _userInput;
        private readonly IFlightScheduleFactory _flightScheduleFactory;
        private readonly IFlightSchedulerParserFromUserInput<AirFreightCargoFlight> _flightDetailsParser;
        private FlightsScheduleList<AirFreightCargoFlight> _flightsSchedulingList;

        public AirFreightFlightSchedulingViaUserInputService(string userInput, IFlightScheduleFactory flightScheduleFactory, IFlightSchedulerParserFromUserInput<AirFreightCargoFlight> flightDetailsParser)
        {
            _userInput = userInput;
            _flightScheduleFactory = flightScheduleFactory;
            _flightDetailsParser = flightDetailsParser;
        }

        public FlightsScheduleList<AirFreightCargoFlight> CreateFlightsScheduleList()
        {
            if (!string.IsNullOrEmpty(_userInput))
            {
                _flightsSchedulingList = new();
                // Split the schedule into lines
                string[] lines = _userInput.Split('\n');
                FlightsSchedule<AirFreightCargoFlight> flightSchedule = null;

                foreach (var line in lines)
                {
                    // Check if the line contains "Day" to determine the day
                    if (line.StartsWith("Day"))
                    {
                        int currentDay = _flightDetailsParser.ParseDayValue(line);
                        flightSchedule = _flightScheduleFactory.CreateFlightsSchedule<AirFreightCargoFlight>();
                        _flightsSchedulingList.AddPerDayFlightsSchedule(flightSchedule);

                        if (flightSchedule is PerDayFlightsSchedule<AirFreightCargoFlight> perDay)
                        {
                            perDay.Day = currentDay;
                        }
                    }
                    else
                    {
                        var flight = _flightDetailsParser.ParseFlightDetailsFromUserInput(line);
                        if (flight != null)
                        {
                            flightSchedule.Flights.Add(flight);
                        }
                    }
                }
                return _flightsSchedulingList;
            }
            return null;
        }

        public string GetDisplayString()
        {
            return _flightsSchedulingList.ToString();
        }
    }
}
