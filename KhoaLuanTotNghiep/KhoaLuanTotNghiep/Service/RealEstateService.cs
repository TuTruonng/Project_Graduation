using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Enum;
using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class RealEstateService : IRealEstate
    {
        private readonly ApplicationDbContext _dbContext;

        public RealEstateService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RealEstateModel> CreateRealEstatesAsync(RealEstateModel realEstateModel)
        {
            var realEstate = await _dbContext.category.FirstOrDefaultAsync(p => p.CategoryID == realEstateModel.CategoryID);
            if (realEstate == null)
            {
                throw new Exception("Have not Category");
            }
            realEstateModel.RealEstateID = Guid.NewGuid().ToString();
            var Model = new RealEstate
            {
                RealEstateID = realEstateModel.RealEstateID,
                CategoryID = realEstateModel.CategoryID,
                UserID = realEstateModel.UserID,
                ReportID = realEstateModel.ReportID,
                Title = realEstateModel.Title,
                Price = realEstateModel.Price,
                Image = realEstateModel.Image,
                Description = realEstateModel.Description,
                Acreage = realEstateModel.acreage,
                Slug = realEstateModel.Slug,
                Approve = (int)StateApprove.FALSE,
                Status = realEstateModel.Status,
                PhoneNumber = realEstateModel.PhoneNumber,
                Location = realEstateModel.Location,
            };
            var create = _dbContext.Add(Model);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return realEstateModel;
            }
            throw new Exception("Create News Fail");

        }

        public async Task<IEnumerable<RealEstateModel>> GetAllAsync()
        {
            var queryable = _dbContext.realEstates.Include(x => x.category).AsQueryable();
          queryable = queryable.Where(x => x.Approve == (short)StateApprove.TRUE);
            var list = await  queryable.Select(p => new RealEstateModel
                {
                    RealEstateID = p.RealEstateID,
                    CategoryID = p.CategoryID,
                    UserID = p.UserID,
                    CategoryName = p.category.CategoryName,
                    ReportID = p.ReportID,
                    Title = p.Title,
                    Price = p.Price,
                    Image = p.Image,
                    Description = p.Description,
                    acreage = p.Acreage,
                    Slug = p.Slug,
                    Approve = p.Approve,
                    Status = p.Status,
                    PhoneNumber = p.PhoneNumber,
                    Location = p.Location,
                }).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<RealEstateModel>> GetListApproveAsync()
        {
            var queryable = _dbContext.realEstates.Include(x => x.category).AsQueryable();
            var list = await queryable.Select(p => new RealEstateModel
            {
                RealEstateID = p.RealEstateID,
                CategoryID = p.CategoryID,
                UserID = p.UserID,
                CategoryName = p.category.CategoryName,
                ReportID = p.ReportID,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image,
                Description = p.Description,
                acreage = p.Acreage,
                Slug = p.Slug,
                Approve = p.Approve,
                Status = p.Status,
                PhoneNumber = p.PhoneNumber,
                Location = p.Location,
            }).ToListAsync();
            return list;
        }

        public async Task<RealEstateModel> UpdateRealEstateAsync(string id, RealEstateModel realEstateModel)
        {
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == id);
            if (realEstate == null)
            {
                throw new Exception("Have not NewsID");
            }
            realEstate.Approve = realEstateModel.Approve;
            realEstate.PhoneNumber = realEstateModel.PhoneNumber;
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return realEstateModel;
            }
            throw new Exception("Update  fail");
        }

        public async Task<bool> DeleteRealEstateModelAsync(string id, StateApprove stateApprove)
        {
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == id);
            if (realEstate == null)
            {
                throw new Exception("Have not RealEstate");
            }
            realEstate.Approve = (int)stateApprove;
            var delete = _dbContext.Remove(realEstate);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            throw new Exception("Delete fail");

        }

        public async Task<bool> DisableAsync(string id, StateApprove stateApprove)
        {
            var realEstate = await _dbContext.realEstates.FindAsync(id);
            if(realEstate == null)
            {
                throw new Exception("Have not Real Estate");    
            }
            realEstate.Approve = (int)stateApprove;
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            throw new Exception(" Change state fail");
        }
    }
}
