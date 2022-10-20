namespace OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices
{
    public interface IClientSession
    {
        string SessionId { get; }
        string DeviceId { get; }
    }
}