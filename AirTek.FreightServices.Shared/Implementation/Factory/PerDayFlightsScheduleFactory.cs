﻿using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory;
using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Implementation.Factory
{
    public class PerDayFlightsScheduleFactory : IFlightScheduleFactory
    {
        public FlightsSchedule<T> CreateFlightsSchedule<T>() where T : IFlight
        {
            return new PerDayFlightsSchedule<T>();
        }
    }
}
