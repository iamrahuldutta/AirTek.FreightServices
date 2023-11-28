using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Internal;
using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Models.Flight;
using System.Text.RegularExpressions;

namespace AirTek.FreightServices.FlightsServices.Implemenation.InputParsers
{
    public class AirFreightFlightSchedulerParserFromUserInput : IFlightSchedulerParserFromUserInput<AirFreightCargoFlight>
    {
        private readonly IAirFreightCargoFlightFactory _flightFactory;
        private readonly IFlightDataService _flightDataService;
        public AirFreightFlightSchedulerParserFromUserInput(IAirFreightCargoFlightFactory flightFactory, IFlightDataService flightDataService)
        {
            _flightFactory = flightFactory;
            _flightDataService = flightDataService;
        }

        public int ParseDayValue(string userInput)
        {
            return int.Parse(userInput.Substring(4, userInput.IndexOf(':') - 4).Trim());
        }

        public AirFreightCargoFlight ParseFlightDetailsFromUserInput(string userInput)
        {
            AirFreightCargoFlight flight = null;
            if (string.IsNullOrEmpty(userInput))
            {
                return flight;
            }

            // Define a regular expression pattern to match flight information
            string pattern = @"Flight (\d+): (.+) \((\w+)\) to (.+) \((\w+)\)";
            // Use regular expression to match flight information
            Match match = Regex.Match(userInput, pattern);

            if (!match.Success)
            {
                return flight;
            }

            int flightNumber = int.Parse(match.Groups[1].Value);
            string departureCityValue = match.Groups[2].Value;
            string departureCodeValue = match.Groups[3].Value;
            string destinationCityValue = match.Groups[4].Value;
            string destinationCodeValue = match.Groups[5].Value;

            var departure = _flightFactory.CreateCityInformation(departureCityValue, departureCodeValue);
            var arrival = _flightFactory.CreateCityInformation(destinationCityValue, destinationCodeValue);
            flight = _flightFactory.CreateAirFreightCargoFlight(flightNumber, _flightDataService.GetDefaultFlightCapacity(), departure, arrival);
            return flight;
        }
    }
}
