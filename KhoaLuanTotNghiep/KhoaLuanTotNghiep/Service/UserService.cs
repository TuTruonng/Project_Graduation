using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class UserService:IUser
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var user = await _dbContext.Users.ToListAsync();
            return user;



        }
    }
}
