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

        Task<IEnumerable<RealEstateModel>> GetListApproveAsync();

        Task<RealEstateModel> CreateRealEstatesAsync(RealEstateModel realEstateModel);

        Task<RealEstateModel> UpdateRealEstateAsync(string id, RealEstateModel realEstateModel);

        Task<bool> DeleteRealEstateModelAsync(string id, StateApprove stateApprove);

        Task<bool> DisableAsync(string id, StateApprove stateApprove);
    }
}
