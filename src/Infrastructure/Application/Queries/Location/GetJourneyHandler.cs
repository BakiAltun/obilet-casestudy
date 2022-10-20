using MediatR;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices.Models;
using OBilet.CaseStudy.ApplicationCore.Queries;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Infrastructure.Application.Queries.Location
{
    public class GetJourneyHandler : IRequestHandler<GetJourneyQuery, JourneyResult>
    {
        private readonly IJourneyApiService _journeyApiService;

        public GetJourneyHandler(IJourneyApiService journeyApiService)
        {
            _journeyApiService = journeyApiService;
        }

        public async Task<JourneyResult> Handle(GetJourneyQuery request, CancellationToken cancellationToken)
        {
            var busLocations = await _journeyApiService.GetBusJourneys(request.OriginId, request.DestinationId, request.DepartureDate);

            return new JourneyResult(busLocations.Data.OrderBy(x=> x.Journey.Departure).Select(MapToModel).ToList());
        }

        private JourneyResult.Item MapToModel(BusJourneyResponseModel.Item requestModel)
        {
            return new()
            {
                Id = requestModel.Id,
                Arrival = requestModel.Journey.Arrival,
                Currency = requestModel.Journey.Currency,
                Departure = requestModel.Journey.Departure,
                Destination = requestModel.Journey.Destination,
                DestinationLocation = requestModel.DestinationLocation,
                OriginLocation = requestModel.OriginLocation,
                OriginLocationId = requestModel.OriginLocationId,
                DestinationLocationId = requestModel.DestinationLocationId,
                InternetPrice = requestModel.Journey.InternetPrice,
                Origin = requestModel.Journey.Origin, 
            };
        }
    }
}
