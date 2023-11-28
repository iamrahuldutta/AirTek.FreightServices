﻿using System.Text;

namespace AirTek.FreightServices.Shared.Models.Flight
{
    public record FlightsSchedule<T> where T : Flight
    {
        public ICollection<T> Flights { get; } = new List<T>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var flight in Flights)
            {
                sb.AppendLine(flight.ToString());
            }

            return sb.ToString();
        }
    }
}