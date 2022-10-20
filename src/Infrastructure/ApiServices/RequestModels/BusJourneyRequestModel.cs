using System.Text.Json.Serialization;

namespace OBilet.CaseStudy.Infrastructure.ApiServices.RequestModels
{
    public class BusJourneyRequestModel : BaseRequestModel<BusJourneyRequestModel.Item>
    {

        public class Item
        {
            [JsonPropertyName("origin-id")]
            public int OriginId { get; set; }

            [JsonPropertyName("destination-id")]
            public int DestinationId { get; set; }

            [JsonPropertyName("departure-date")]
            public string DepartureDate{ get; set; }
             
        }
    }
}