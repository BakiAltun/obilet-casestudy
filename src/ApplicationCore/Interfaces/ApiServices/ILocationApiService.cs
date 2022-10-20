using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices
{
    public interface ILocationApiService
    {
        Task<BusLocationResponseModel> GetBusLocations(string search);
    }
}