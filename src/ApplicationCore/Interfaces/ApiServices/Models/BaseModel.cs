using System.Text.Json.Serialization;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices
{
    public class BaseModel<T> where T : class 
    { 
        public string Status { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        [JsonPropertyName("user-message")]
        public string UserMessage { get; set; }
         
        [JsonPropertyName("api-request-id")]
        public string ApiRequestId { get; set; }

        [JsonPropertyName("controller")]
        public string Controller { get; set; }

        [JsonPropertyName("client-request-id")]
        public string ClientRequestId { get; set; }
    }
}