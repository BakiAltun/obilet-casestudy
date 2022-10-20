using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBilet.CaseStudy.ApplicationCore.Interfaces;
using OBilet.CaseStudy.ApplicationCore.Queries;
using OBilet.CaseStudy.Presentation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Presentation.Web.ViewComponents
{
    public class SearchLocationViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly ICookieManager _cookieManager;
        public SearchLocationViewComponent(IMediator mediator, ICookieManager cookieManager)
        {
            _mediator = mediator;
            _cookieManager = cookieManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var searchModel = _cookieManager.Get<SearchModel>();

            SearchLocationViewModel viewModel = new()
            {
                Destination = searchModel?.Destination,
                Origin = searchModel?.Origin,
                DepartureDate = GetDateByGeMinDate(searchModel?.DepartureDate ?? DateTime.Now.AddDays(1), DateTime.Now), // cache de yoksa yarını gösterir ve minimum bugun olmalı
                DestinationId = searchModel?.DestinationId ?? 0,
                OriginId = searchModel?.OriginId ?? 0
            };

            if (searchModel == null) // default değerleri ver
                await SetDefault(viewModel);

            return View(viewModel);
        }

        /// <summary>
        /// Default değerler verilir
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private async Task SetDefault(SearchLocationViewModel viewModel)
        {
            var origin = await GetLocationByName("İstanbul");
            var destination = await GetLocationByName("Sakarya");

            viewModel.Origin = origin.Text;
            viewModel.OriginId = ToInt(origin.Value);
            viewModel.Destination = destination.Text;
            viewModel.DestinationId = ToInt(destination.Value);
        }

        /// <summary>
        /// Min tarihten büyük olan tarihi verir
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="minDate"></param>
        /// <returns></returns>
        private DateTime GetDateByGeMinDate(DateTime? dateTime, DateTime minDate)
        {
            if (dateTime == null)
                return minDate;

            if (dateTime < minDate)
                return minDate;

            return dateTime.Value;
        }

        /// <summary>
        /// Lokasyon adına göre kaydı getirir
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private async Task<SelectListItem> GetLocationByName(string search)
        {
            var result = await _mediator.Send(new GetLocationQuery(search));
            return result.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).FirstOrDefault();
        }

        private int ToInt(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            return int.TryParse(str, out int result) ? result : 0;
        }
    }
}
