using KhoaLuanTotNghiep_BackEnd.Enum;
using KhoaLuanTotNghiep_BackEnd.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[Controller]")]
    [ApiController]

    public class RealEstateController : ControllerBase
    {
        public readonly IRealEstate _realStateService;

        public RealEstateController(IRealEstate realStatrService)
        {
            _realStateService = realStatrService;
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public async Task<ActionResult<RealEstateModel>> Get()
        {
            var product = await _realStateService.GetAllAsync();
            return Ok(product);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<RealEstateModel>> GetListApprove()
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _realStateService.GetListApproveAsync());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<RealEstateModel>> CreateAsync(RealEstateModel realEstate)
        {
            if (!ModelState.IsValid) return BadRequest(realEstate);
            return Ok(await _realStateService.CreateRealEstatesAsync(realEstate));

        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<ActionResult<RealEstateModel>> DeleteAsync(string id)
        {
            if (!ModelState.IsValid) return BadRequest(id);
            return Ok(await _realStateService.DeleteRealEstateModelAsync(id, StateApprove.TRUE));
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult<RealEstateModel>> UpdateAsync(string id, RealEstateModel realEstate)
        {
            if (!ModelState.IsValid) return BadRequest(id);
            return Ok(await _realStateService.UpdateRealEstateAsync(id, realEstate));
        }
    }
}
