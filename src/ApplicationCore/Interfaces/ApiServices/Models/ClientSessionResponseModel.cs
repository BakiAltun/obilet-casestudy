using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models
{
    public class ClientSessionResponseModel : BaseModel<ClientSessionResponseModel.Item>
    { 

        public class Item
        { 

            [JsonPropertyName("session-id")]
            public string SessionId { get; set; }

            [JsonPropertyName("device-id")]
            public string DeviceId { get; set; }

            [JsonPropertyName("affiliate")]
            public string Affiliate { get; set; }

            [JsonPropertyName("device-type")]
            public long DeviceType { get; set; }

            [JsonPropertyName("device")]
            public string Device { get; set; }

        }
    } 
}