using Gremlin.Net.Process.Traversal;
using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
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
        
        public async Task<IEnumerable<RealEstateModel>> GetAllAsync()
        {
            var product = await _dbContext.realEstates.Include(p => p.category).Join(
            _dbContext.Users,
            p => p.UserID,
            u => u.Id,
            (p, u) =>
                new RealEstateModel
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
                    acreage = p.Acgreage,
                    Slug = p.Slug,
                    Approve = p.Approve,
                    Status = p.Status,
                    PhoneNumber = Int32.Parse(u.PhoneNumber),
                    CreateTime = p.CreateTime,
                    UpdateTime = p.UpdateTime,
                    Location = p.Location,
                }).ToListAsync();
            return product;
            
        }

        public async Task<RealEstateModel> CreateRealEstatesAsync(RealEstateModel realEstateModel)
        {
            var realEstate = await _dbContext.categories.FirstOrDefaultAsync(p => p.CategoryID == realEstateModel.CategoryID);
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
                Acgreage = realEstateModel.acreage,
                Slug = realEstateModel.Slug,
                Approve = realEstateModel.Approve,
                Status = realEstateModel.Status,
                //PhoneNumber = realEstateModel.PhoneNumber,
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

        public async Task<RealEstateModel> GetByIdAsync(string id)
        {
            var product = await _dbContext.realEstates.Include(p => p.category).Where(p => p.RealEstateID == id).Join(
            _dbContext.Users,
            p => p.UserID,
            u => u.Id,
            (p, u) =>

               new RealEstateModel
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
                   acreage = p.Acgreage,
                   Slug = p.Slug,
                   Approve = p.Approve,
                   Status = p.Status,
                   PhoneNumber = Int32.Parse(u.PhoneNumber),
                   Location = p.Location,
               }).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<RealEstatefromCategory>> GetByCategoryAsync(string categoryName)
        {
            var products = await _dbContext.realEstates.Include(p => p.category)
                .Where(p => p.category.CategoryName == categoryName)
                .Select(p =>
           
                new RealEstatefromCategory
                 {                 
                     Title = p.Title,
                     Description = p.Description,
                     Price = p.Price,
                     Image = p.Image,
                     CategoryName = p.category.CategoryName
                 }).ToListAsync();

            return products;
        }

        public async Task<RealEstate> DeleteAsync(int id)
        {
            var product = await _dbContext.realEstates.FindAsync(id);
            if (product == null)
                return null;
            _dbContext.realEstates.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public Task<RealEstateModel> UpdateRealEstateAsync(string id, RealEstateModel realEstateModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRealEstateModelAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
