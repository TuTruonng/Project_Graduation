using KhoaLuanTotNghiep_BackEnd.Enum;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Interface
{
    public interface IRealEstate
    {
        Task<IEnumerable<RealEstateModel>> GetAllAsync();

        Task<RealEstateModel> CreateRealEstatesAsync(RealEstateModel realEstateModel);

        Task<RealEstateModel> UpdateRealEstateAsync(string id, RealEstateModel realEstateModel);

        Task<bool> DeleteRealEstateModelAsync(string id);
<<<<<<< HEAD
=======

        Task<IEnumerable<RealEstatefromCategory>> GetByCategoryAsync(string categoryName);

        Task<RealEstateModel> GetByIdAsync(string id);
>>>>>>> 463f3093853a650cbe23a8a0ed6670a2c5dd17e3
    }
}
