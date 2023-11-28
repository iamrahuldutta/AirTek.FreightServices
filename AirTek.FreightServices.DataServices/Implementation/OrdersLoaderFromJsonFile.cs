using AirFreightServices.Data.Models;
using AirTek.FreightServices.DataServices.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirTek.FreightServices.DataServices.Implementation
{
    public class OrdersLoaderFromJsonFile : IOrdersLoader
    {
        private readonly string _filePath;

        public OrdersLoaderFromJsonFile(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<OrderDataModel> LoadOrders()
        {
            string json;

            using (StreamReader r = new(_filePath))
            {
                json = await r.ReadToEndAsync();
            }
            if (json != null)
            {
                JObject o = JObject.Parse(json);
                OrderDataModel orderDataModel = new OrderDataModel();
                orderDataModel.Orders = new Dictionary<string, OrderDetailsDataModel>();

                foreach (var obj in o.Children())
                {
                    var jProperty = (JProperty)obj;
                    orderDataModel.Orders.Add(jProperty.Name, JsonConvert.DeserializeObject<OrderDetailsDataModel>(jProperty.Value.ToString()));
                }
                return orderDataModel;
            }
            return null;
        }
    }
}
