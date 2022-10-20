using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models;
using OBilet.CaseStudy.Infrastructure.ApiServices.RequestModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Infrastructure.ApiServices
{
    public class LocationApiService : BaseApiService, ILocationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientSession _clientSession;
        public LocationApiService(HttpClient httpClient, IClientSession clientSession)
        {
            _httpClient = httpClient;
            _clientSession = clientSession;
        } 

        public async Task<BusLocationResponseModel> GetBusLocations(string search)
        { 
            var requestModel = new BusLocationRequestModel()
            {
                RequestDate = DateTime.Now,
                Language = "tr-TR",
                DeviceSession =
                {
                    DeviceId =_clientSession.DeviceId,
                    SessionId = _clientSession.SessionId,
                },
                Data = search
            };
             
            return await _httpClient.PostAsync<BusLocationResponseModel, BusLocationRequestModel>("location/getbuslocations", requestModel); 
        }
    }
}