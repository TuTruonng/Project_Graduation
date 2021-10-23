using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using ShareModel;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class RateService : IRate
    {
        private readonly ApplicationDbContext _applicationDb;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RateService(ApplicationDbContext applicationDb, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDb = applicationDb;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<bool> CreateRate(CreateRatingRequest rateShare)
        {
            var rates = new Rate { RealEstateId = rateShare.ProductId, Value = rateShare.value };

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            rates.UserId = userId.ToString();
            _applicationDb.Add(rates);
            await _applicationDb.SaveChangesAsync();
            return true;

        }
    }
}
