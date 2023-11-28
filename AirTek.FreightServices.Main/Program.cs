using AirTek.FreightServices.Main.Implementation;
using AirTek.FreightServices.Shared.Models.Flight;
using AirTek.FreightServices.Shared.Models.Order;
using System.Text;

namespace AirTek.FreightServices.Main
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PrintSampleInput();
            PrintInputRequest();
            var userInput = GetUserInput();
            var flightSchedule = LoadAirFreightCargoSchedule(userInput);
            var orders = await LoadOrders();
            AssignOrdersToFreightTransport(flightSchedule, orders);
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

        private static List<FreightTransportSchedule<AirFreightFlight>> LoadAirFreightCargoSchedule(string userInput)
        {
            var flightSchedulingService = new AirFreightCargoFlightBuilder<AirFreightFlight>().WithUserInput(userInput).Build();
            return flightSchedulingService;
        }

        private static async Task<OrderData> LoadOrders()
        {
            return await new OrdersLoaderBuilder().WithJsonFilePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "coding-assigment-orders.json"))
                .Build();
        }

        private static void AssignOrdersToFreightTransport(List<FreightTransportSchedule<AirFreightFlight>> freightTransportSchedules, OrderData orderData)
        {
            new AddOrdersToFlightBuilder<AirFreightFlight>().WithSchedule(freightTransportSchedules).WithOrders(orderData).Build();
        }
    }
}