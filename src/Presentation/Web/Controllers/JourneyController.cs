using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using OBilet.CaseStudy.ApplicationCore.Queries;
using OBilet.CaseStudy.Presentation.Web.Models;
using OBilet.CaseStudy.ApplicationCore.Interfaces;

namespace OBilet.CaseStudy.Presentation.Web.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICookieManager _cookieManager;
        public JourneyController(IMediator mediator, ICookieManager cookieManager)
        {
            _mediator = mediator;
            _cookieManager = cookieManager;
        }

        [Route("seferler/{originId}-{destinationId}/{departureDate}")]
        public async Task<IActionResult> Index(SearchModel searchModel)
        {  
            var result = await _mediator.Send(new GetJourneyQuery(searchModel.OriginId, searchModel.DestinationId, searchModel.DepartureDate));

            return View(new JourneyViewModel(result, _cookieManager.Get<SearchModel>()));
        }

        public ActionResult Redirect(SearchModel searchModel)
        {
            _cookieManager.Set(searchModel);
            return RedirectToAction("Index", "Journey", new
            {
                searchModel.OriginId,
                searchModel.DestinationId,
                departureDate = searchModel.DepartureDate.ToString("yyyy-MM-dd")
            });
        }

        [Route("seferler/{originId}-{destinationId}/{departureDate}/{journeyId}")]
        public ActionResult RedirectExternal()
        {
            return Redirect("https://www.obilet.com" + Request.Path);
        }
    }
}
