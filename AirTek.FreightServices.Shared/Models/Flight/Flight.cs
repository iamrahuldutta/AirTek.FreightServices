﻿namespace AirTek.FreightServices.Shared.Models.Flight
{
    public abstract record Flight(int FlightNumber, CityInformation Departure, CityInformation Arrival)
    {
        
    }
}
