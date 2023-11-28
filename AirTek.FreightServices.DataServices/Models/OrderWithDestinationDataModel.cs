using System.Runtime.Serialization;

namespace AirFreightServices.Data.Models
{
    [DataContract]
    public class OrderDetailsDataModel
    {
        [DataMember]
        public string Destination { get; set; }
    }
}
