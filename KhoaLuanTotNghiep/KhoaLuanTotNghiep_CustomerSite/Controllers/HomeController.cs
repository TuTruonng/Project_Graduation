using KhoaLuanTotNghiep_CustomerSite.Models;
using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRealEstateApiClient _realestateApiClient;

        public HomeController(ILogger<HomeController> logger, IRealEstateApiClient productApiClient)
        {
            _logger = logger;
            _realestateApiClient = productApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _realestateApiClient.GetProducts();
            return View(results);
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
