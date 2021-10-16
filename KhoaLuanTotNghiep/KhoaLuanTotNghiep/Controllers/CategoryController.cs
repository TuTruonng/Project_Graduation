using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
   // [Authorize("Bearer")]
    public class CategoryController : ControllerBase
    {
        private readonly Icategory _categoryService;

        public CategoryController (Icategory categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetListAsync()
        {
            return Ok(await _categoryService.GetListCategoryAsync());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryModel>> CreateAsync(CategoryModel Model)
        {
            if (!ModelState.IsValid) return BadRequest(Model);
            return Ok(await _categoryService.CreateCategoryAsync(Model));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateAsync(int id, CategoryModel category)
        {
            if (!ModelState.IsValid) return BadRequest("Category Id is not valid");         
            return Ok(await _categoryService.UpdateCategoryAsync(id, category));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Category Id is not valid");
            return Ok(await _categoryService.DeleteCategoryAsync(id));
        }
    }
}
