using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRealEstateApiClient _productApiClient;

        public ProductController(IRealEstateApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        [Route("/RealEstate")]
        public async Task<IActionResult> Index()
        {
            var results = await _productApiClient.GetProducts();
            return View(results);
        }

        [Route("/RealEstate/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var result = await _productApiClient.GetProductById(id);
            return View(result);
        }

        [Route("/Prodcut/category{categoryName}")]
        public async Task<IActionResult> CategoryById(string categoryName)
        {
            var results = await _productApiClient.GetProductByCategory(categoryName);
            return View(results);
        }
    }
}
