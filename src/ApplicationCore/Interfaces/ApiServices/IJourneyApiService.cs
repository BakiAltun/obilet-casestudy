using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices
{
    public interface IJourneyApiService
    {
        Task<BusJourneyResponseModel> GetBusJourneys(int originId, int destinationId, DateTime departureDate);
    }
}