using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models
{
    public class BusLocationResponseModel : BaseModel<IEnumerable<BusLocationResponseModel.Item>>
    {



        public class Item
        { 
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("parent-id")]
            public int ParentId { get; set; }

            public string Type { get; set; }

            public string Name { get; set; }

            [JsonPropertyName("geo-location")]
            public GeoLocationItem GeoLocation { get; set; }

            public int Zoom { get; set; }

            [JsonPropertyName("tz-code")]
            public string TzCode { get; set; }


            [JsonPropertyName("weather-code")]
            public string WeatherCode { get; set; }
            public int? Rank { get; set; }

            [JsonPropertyName("reference-code")]
            public string ReferenceCode { get; set; }
            public string Keywords { get; set; }


            public class GeoLocationItem
            {
                public double Latitude { get; set; }
                public double Longitude { get; set; }
                public int zoom { get; set; }
            }
        }
    }
}