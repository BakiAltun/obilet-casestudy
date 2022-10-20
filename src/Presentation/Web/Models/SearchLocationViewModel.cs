using Microsoft.AspNetCore.Mvc.Rendering; 
using System; 
using System.Collections.Generic;

namespace OBilet.CaseStudy.Presentation.Web.Models
{
    public class SearchLocationViewModel : SearchModel
    {
        public IList<SelectListItem> Locations { get; set; }
    }

    public class SearchModel
    {
        public int OriginId { get; set; }
        public string Origin { get; set; }
        public int DestinationId { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
