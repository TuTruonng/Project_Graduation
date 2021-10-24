using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]

    public class RateController : ControllerBase
    {
        private readonly IRate _rate;

        public RateController(IRate rate)
        {
            _rate = rate;

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRate(CreateRatingRequest rateShare)
        {
            var result = await _rate.CreateRate(rateShare);
            return Ok(result);
        }
    }
}
