using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using OBilet.CaseStudy.ApplicationCore.Queries;

namespace OBilet.CaseStudy.Presentation.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Get()
        {

            return View();
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectList(string search)
        {
            var result = await _mediator.Send(new GetLocationQuery(search)); 
            return result.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }
    } 
} 