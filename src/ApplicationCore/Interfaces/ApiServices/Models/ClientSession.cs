using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;

namespace OBilet.CaseStudy.ApplicationCore.ApiServices.Models
{
    public class ClientSession : IClientSession
    {
        public string SessionId { get; set; }
        public string DeviceId { get; set; }
    }
}