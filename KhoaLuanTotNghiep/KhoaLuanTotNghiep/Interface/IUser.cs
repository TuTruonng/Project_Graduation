using KhoaLuanTotNghiep_BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUserAsync();
    }
}
