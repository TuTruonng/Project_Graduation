using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_CustomerSite.Service
{
    public interface IRealEstateApiClient
    {
        Task<IList<RealEstateModel>> GetProducts();

        Task<RealEstateModel> GetProductById(string id);

        Task<IList<RealEstatefromCategory>> GetProductByCategory(string categoryName);

        Task<bool> Rating(int productId, int values);
    }
}
