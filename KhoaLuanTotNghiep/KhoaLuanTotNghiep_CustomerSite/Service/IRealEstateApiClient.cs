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

        Task<IEnumerable<RealEstatefromCategory>> GetProductByCategory(string categoryName);

        Task<bool> Rating(string productId, int values);
    }
}
