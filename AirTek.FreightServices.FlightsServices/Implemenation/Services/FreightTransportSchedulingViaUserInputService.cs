using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Interfaces.Factory.Models;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.FlightsServices.Implemenation.Services
{
    public class FreightTransportSchedulingViaUserInputService<T> : IFreightTransportSchedulingService<T>  where T : IFreightTransportWithCapacity
    {
        private readonly string _userInput;
        private readonly IFreightTransportScheduleFactory _flightScheduleFactory;
        private readonly IFreightTransportSchedulerParserFromUserInput _flightDetailsParser;
        private FreightTransportScheduleList<T> _flightsSchedulingList;

        public FreightTransportSchedulingViaUserInputService(string userInput, IFreightTransportScheduleFactory flightScheduleFactory, IFreightTransportSchedulerParserFromUserInput flightDetailsParser)
        {
            _userInput = userInput;
            _flightScheduleFactory = flightScheduleFactory;
            _flightDetailsParser = flightDetailsParser;
        }

        public FreightTransportScheduleList<T> CreateFlightsScheduleList()
        {
            if (!string.IsNullOrEmpty(_userInput))
            {
                _flightsSchedulingList = new();
                // Split the schedule into lines
                string[] lines = _userInput.Split('\n');
                FreightTransportSchedule<T> flightSchedule = null;

                foreach (var line in lines)
                {
                    // Check if the line contains "Day" to determine the day
                    if (line.StartsWith("Day"))
                    {
                        int currentDay = _flightDetailsParser.ParseDayValue(line);
                        flightSchedule = _flightScheduleFactory.CreateFreightTransportSchedule<T>();
                        _flightsSchedulingList.AddPerDayFlightsSchedule(flightSchedule);

                        if (flightSchedule is PerDayFreightTransportSchedule<T> perDay)
                        {
                            perDay.Day = currentDay;
                        }
                    }
                    else
                    {
                        var flight = _flightDetailsParser.ParseTransportDetailsFromUserInput<T>(line);
                        if (flight != null)
                        {
                            flightSchedule.FreightTransport.Add(flight);
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
