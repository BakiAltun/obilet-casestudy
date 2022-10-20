using Microsoft.AspNetCore.Mvc.Rendering;
using OBilet.CaseStudy.ApplicationCore.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OBilet.CaseStudy.Presentation.Web.Models
{
    public class JourneyViewModel : SearchModel
    {
        public JourneyViewModel(JourneyResult journey, SearchModel searchModel)
        {
            Journey = journey;
             
            Header = Journey?.Items?.Any() == true ? new HeaderItem(Journey.Items.FirstOrDefault()) : new HeaderItem(searchModel);
        }

        public JourneyResult Journey { get; set; }

        public HeaderItem Header { get; private set; }

        public class HeaderItem
        {
            public HeaderItem(JourneyResult.Item journeyResult)
            {
                Title = $"{journeyResult.OriginLocation} - {journeyResult.DestinationLocation}";
                Date = journeyResult.Departure.ToString("dd MMMM dddd", new CultureInfo("tr-TR"));
            }

            public HeaderItem(SearchModel searchModel)
            {
                Title = $"{searchModel.Origin} - {searchModel.Destination}";
                Date = searchModel.DepartureDate.ToString("dd MMMM dddd", new CultureInfo("tr-TR"));
            }

            public string Title { get; set; }
            public string Date { get; set; }
        }
    }
}
