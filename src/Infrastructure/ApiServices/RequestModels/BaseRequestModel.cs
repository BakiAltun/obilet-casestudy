using System;
using System.Text.Json.Serialization;

namespace OBilet.CaseStudy.Infrastructure.ApiServices.RequestModels
{
    public class BaseRequestModel<T>  
    {
        public T Data { get; set; }

        [JsonPropertyName("device-session")] 
        public DeviceSessionItem DeviceSession { get; set; } = new();
        public class DeviceSessionItem
        {
            [JsonPropertyName("session-id")]
            public string SessionId { get; set; }

            [JsonPropertyName("device-id")]
            public string DeviceId { get; set; }
        }


        private DateTime _requestDate;

        [JsonIgnore]
        public DateTime RequestDate
        {
            get => _requestDate;
            set
            {
                _requestDate = value; Date = value.ToString("s");
            }
        }

        public string Date { get; private set; }

        public string Language { get; set; }
    }
}