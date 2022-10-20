using MediatR;
using OBilet.CaseStudy.ApplicationCore.Interfaces;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models;
using OBilet.CaseStudy.ApplicationCore.Queries;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Infrastructure.Application.Queries.Location
{
    public class GetLocationHandler : IRequestHandler<GetLocationQuery, LocationResult>
    {
        private readonly ILocationApiService _locationApiService;
        private readonly ICacheManager _cacheManager;
        public GetLocationHandler(ILocationApiService locationApiService, ICacheManager cacheManager)
        {
            _locationApiService = locationApiService;
            _cacheManager = cacheManager;
        }

        public async Task<LocationResult> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Search))
                return await GetSearch(request.Search);

            return await _cacheManager.GetOrCreate(GetAll);
        }

        private async Task<LocationResult> GetSearch(string search)
        {
            var busLocations = await _locationApiService.GetBusLocations(search);
            return new LocationResult(busLocations.Data.Select(MapToModel).ToList());
        }

        private async Task<LocationResult> GetAll()
        {
            var busLocations = await _locationApiService.GetBusLocations(null);
            return new LocationResult(busLocations.Data.Take(10).Select(MapToModel).ToList());
        }

        private LocationResult.Item MapToModel(BusLocationResponseModel.Item requestModel)
        {
            return new()
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
            };
        }
    }
}
