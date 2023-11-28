﻿using AirTek.FreightServices.Shared.Interfaces;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record AirFreightCargoFlight(int FlightNumber, int Capacity, CityInformation Departure, CityInformation Arrival)
        : Flight(FlightNumber, Departure, Arrival), IAirFreightCargoFlight
    {
        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {Departure.Abbreviation}, arrival: {Arrival.Abbreviation}";
        }
    }
}
