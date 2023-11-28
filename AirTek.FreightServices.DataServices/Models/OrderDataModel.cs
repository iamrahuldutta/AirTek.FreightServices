using System.Runtime.Serialization;

namespace AirFreightServices.Data.Models
{
    [DataContract]
    public class OrderDataModel
    {
        [DataMember]
        public Dictionary<string, OrderDetailsDataModel> Orders { get; set; }
    }
}
