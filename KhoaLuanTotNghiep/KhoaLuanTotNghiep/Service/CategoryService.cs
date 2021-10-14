using KhoaLuanTotNghiep.Data;
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
    public class CategoryService : Icategory
    {
        public readonly ApplicationDbContext _dbContext;
        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CategoryModel> CreateCategoryAsync(CategoryModel categoryModel)
        {
            var category = await _dbContext.category.FirstOrDefaultAsync(x => x.CategoryName == categoryModel.CategoryName);
            if (category != null)
            {
                throw new Exception("Category Name is used");
            }

            var cate = new Category
            {
                CategoryID = categoryModel.CategoryID,
                CategoryName = categoryModel.CategoryName,
                Description = categoryModel.Description,
            };
            var create = _dbContext.Add(cate);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return categoryModel;
            }
            throw new Exception("Create category fail");

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var asset = await _dbContext.category.FirstOrDefaultAsync(x => x.CategoryID == id);
            if (asset == null)
            {
                throw new Exception("Have not this category");
            }
            var deleted = _dbContext.category.Remove(asset);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            throw new Exception("Delete category fail");
        }

        public async Task<ICollection<CategoryModel>> GetListCategoryAsync(CategoryRequestParam requestParam)
        {
            var queryable = _dbContext.category.AsQueryable();
            if (!string.IsNullOrEmpty(requestParam.Query))
                queryable = queryable.Where(x => x.CategoryName.Contains(requestParam.Query));

            return  await queryable.Select(x => new CategoryModel
            {
                CategoryID = x.CategoryID,
                Description = x.Description,
                CategoryName = x.CategoryName,
            }).ToListAsync();
        }

        public async Task<CategoryModel> UpdateCategoryAsync(int id, CategoryModel categoryModel)
        {
            var category = await _dbContext.category.FirstOrDefaultAsync(x => x.CategoryID == id);
            if (category == null)
            {
                throw new Exception("Have not this category");
            }
            category.CategoryName = categoryModel.CategoryName;
            category.Description = categoryModel.Description;
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return categoryModel;
            }
            throw new Exception("Delete category fail");
           
        }
    }
}
