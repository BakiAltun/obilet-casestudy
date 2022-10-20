using Microsoft.AspNetCore.Http;
using OBilet.CaseStudy.ApplicationCore.ApiServices.Models;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models;
using OBilet.CaseStudy.Infrastructure.ApiServices.RequestModels;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Infrastructure.ApiServices
{
    public class ClientApiService : BaseApiService, IClientApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClientApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public IClientSession GetSession()
        {
            var clientSessionResponse = GetClientSessionResponse().GetAwaiter().GetResult();

            return new ClientSession
            {
                DeviceId = clientSessionResponse.Data.DeviceId,
                SessionId = clientSessionResponse.Data.SessionId,
            };
        }

        private async Task<ClientSessionResponseModel> GetClientSessionResponse()
        {
            var content = base.PrepareStringContent(new ClientRequestModel()
            {
                Type = 1,
                Connection = new()
                {
                    IpAddress = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString(),
                    Port = _httpContextAccessor.HttpContext.Connection.LocalPort
                },
                Browser = new()
                {
                    Name = "Chrome",
                    Version = "47.0.0.12"
                }
            });

            return await _httpClient.PostAsync<ClientSessionResponseModel>("Client/getsession", content);
        } 
    }
}