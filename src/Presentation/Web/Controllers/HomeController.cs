using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OBilet.CaseStudy.Presentation.Web.Models;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;

namespace OBilet.CaseStudy.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientApiService _clientApiService;

        public HomeController(IClientApiService clientApiService)
        {
            _clientApiService = clientApiService;
        }

        public IActionResult Index()
        {
            var d = _clientApiService.GetSession();
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
