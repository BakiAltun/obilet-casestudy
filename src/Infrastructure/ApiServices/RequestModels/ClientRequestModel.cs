using System.Text.Json.Serialization;

namespace OBilet.CaseStudy.Infrastructure.ApiServices.RequestModels
{

    public class ClientRequestModel
    {
        public int Type { get; set; }
        public ConnectionItem Connection { get; set; }
        public BrowserItem Browser { get; set; }
        public class ConnectionItem
        {
            [JsonPropertyName("ip-address")]
            public string IpAddress { get; set; }
            public int Port { get; set; }
        }

        public class BrowserItem
        {
            public string Name { get; set; }
            public string Version { get; set; }
        }
    }

}