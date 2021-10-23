using KhoaLuanTotNghiep_BackEnd.Models;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.InterfaceService
{
    public interface IRealEstate
    {
        Task<IEnumerable<RealEstateModel>> GetAllAsync();

        Task<RealEstateModel> CreateRealEstatesAsync(RealEstateModel realEstateModel);

        Task<RealEstateModel> UpdateRealEstateAsync(string id, RealEstateModel realEstateModel);

        Task<bool> DeleteRealEstateModelAsync(string id);

        Task<IEnumerable<RealEstatefromCategory>> GetByCategoryAsync(string categoryName);

        Task<RealEstateModel> GetByIdAsync(string id);
    }
}
