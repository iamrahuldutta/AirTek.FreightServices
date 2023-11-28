﻿using AirFreightServices.OrdersScheduler.Interfaces;
using AirTek.FreightServices.DataServices.Implementation;
using AirTek.FreightServices.DataServices.Interfaces;
using AirTek.FreightServices.Main.Implementation;
using AirTek.FreightServices.OrderServices.Implementation;
using System.Text;

namespace AirTek.FreightServices.Main
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PrintSampleInput();
            PrintInputRequest();
            LoadAirFreightCargoSchedule();
            await LoadOrders();
        }

        private static void PrintSampleInput()
        {
            Console.WriteLine("Sample input");
            Console.WriteLine("********************");
            Console.WriteLine("Day 1:\r\nFlight 1: Montreal airport (YUL) to Toronto (YYZ)\r\nFlight 2: " +
                "Montreal (YUL) to Calgary (YYC)\r\nFlight 3: Montreal (YUL) to Vancouver (YVR)\r\nDay 2:\r\nFlight 4: " +
                "Montreal airport (YUL) to Toronto (YYZ)\r\nFlight 5: Montreal (YUL) to Calgary (YYC)\r\nFlight 6: " +
                "Montreal (YUL) to Vancouver (YVR)");
            Console.WriteLine("********************");
        }

        private static void PrintInputRequest()
        {
            Console.WriteLine("");
            Console.WriteLine("Please use the above given input sample and adjust accordingly, paste the text and then press Enter.");
        }

        private static string GetUserInput()
        {
            var userInput = new StringBuilder();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                userInput.AppendLine(line);
            }
            return userInput.ToString();
        }

        private static void LoadAirFreightCargoSchedule()
        {
            var userInput = GetUserInput();
            var flightSchedulingService = new AirFreightCargoFlightBuilder().WithUserInput(userInput).Build();
            var flightsScheduleList = flightSchedulingService.CreateFlightsScheduleList();
            Console.WriteLine("Flights Schedule Result:");
            Console.WriteLine(flightSchedulingService.GetDisplayString());
        }

        private static async Task LoadOrders()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "coding-assigment-orders.json");
            IOrdersLoader ordersLoader = new OrdersLoaderFromJsonFile(filePath);
            IOrderDataService orderLoader = new OrderDataService(ordersLoader);
            Console.WriteLine((await orderLoader.GetOrders()).ToString());
        }
    }
}