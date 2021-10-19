using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Interface
{
    public interface INews
    {
        Task<ICollection<NewsModel>> GetListNewsAsync();

        Task<NewsModel> CreateNewsAsync(NewsModel newsModel);

        Task<NewsModel> UpdateNewsAsync(string id, NewsModel newsModel);

        Task<bool> DeleteCategoryAsync(string id);
    }
}
