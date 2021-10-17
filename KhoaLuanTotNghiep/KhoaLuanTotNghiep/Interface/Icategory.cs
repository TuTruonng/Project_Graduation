
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Interface
{
    public interface Icategory
    {
        Task<ICollection<CategoryModel>> GetListCategoryAsync(CategoryRequestParam requestParam);

        Task<CategoryModel> CreateCategoryAsync(CategoryModel categoryModel);

        Task<CategoryModel> UpdateCategoryAsync(int id, CategoryModel categoryModel);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
