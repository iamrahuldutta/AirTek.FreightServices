﻿using AirTek.FreightServices.FlightsServices.Interfaces.InputParsers;
using AirTek.FreightServices.FlightsServices.Interfaces.Services;
using AirTek.FreightServices.Shared.Interfaces;
using AirTek.FreightServices.Shared.Interfaces.Factory.Models;

namespace AirTek.FreightServices.FlightsServices.Interfaces.Factory
{
    public interface IFreightTransportSchedulingServiceFactory
    {
        IFreightTransportSchedulingService<T> CreateFreightTransportScheduleViaUserInputService<T>(string userInput, IFreightTransportScheduleFactory flightSchedulePatternFactory, IFreightTransportSchedulerParserFromUserInput flightDetailsParserFromUserInput) where T : IFreightTransportWithCapacity;
    }
}