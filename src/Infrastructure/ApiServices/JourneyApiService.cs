using Microsoft.AspNetCore.Http;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models;
using OBilet.CaseStudy.Infrastructure.ApiServices.RequestModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Infrastructure.ApiServices
{
    public class JourneyApiService : BaseApiService, IJourneyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientSession _clientSession;
        public JourneyApiService(HttpClient httpClient, IClientSession clientSession)
        {
            _httpClient = httpClient;
            _clientSession = clientSession;
        }

        public async Task<BusJourneyResponseModel> GetBusJourneys(int originId, int destinationId, DateTime departureDate)
        {
            var requestModel =new BusJourneyRequestModel()
            {
                RequestDate = DateTime.Now,
                Language = "tr-TR",
                DeviceSession =
                {
                    DeviceId =_clientSession.DeviceId,
                    SessionId = _clientSession.SessionId,
                },
                Data = new BusJourneyRequestModel.Item
                {
                    OriginId = originId,
                    DestinationId = destinationId,
                    DepartureDate = departureDate.ToString("yyyy-MM-dd")
                }
            };

            return await _httpClient.PostAsync<BusJourneyResponseModel, BusJourneyRequestModel>("journey/getbusjourneys", requestModel);
        }
    }
}