using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly IRealEstateApiClient _realestateApiClient;

        public RealEstateController(IRealEstateApiClient productApiClient)
        {
            _realestateApiClient = productApiClient;
        }

        [Route("/RealEstate")]
        public async Task<IActionResult> Index()
        {
            var results = await _realestateApiClient.GetProducts();
            return View(results);
        }

        [Route("/RealEstate/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var result = await _realestateApiClient.GetProductById(id);
            return View(result);
        }

        [Route("/RealEstate/category{categoryName}")]
        public async Task<IActionResult> CategoryById(string categoryName)
        {
            var results = await _realestateApiClient.GetProductByCategory(categoryName);
            return View(results);
        }
    }
}
