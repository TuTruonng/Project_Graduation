using KhoaLuanTotNghiep_BackEnd.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INews _newsService;
        public NewsController(INews newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<NewsModel>>> GetListAsync()
        {
            return Ok(await _newsService.GetListNewsAsync());

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<NewsModel>> CreateAsync(NewsModel newsModel)
        {
            if (!ModelState.IsValid) return BadRequest(newsModel);
            return Ok(await _newsService.CreateNewsAsync(newsModel));

        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("News Id is not valid");
            return Ok(await _newsService.DeleteCategoryAsync(id));

        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<NewsModel>> UpdateAsync(string id,NewsModel newsModel)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("News Id is not valid");
            return Ok(await _newsService.UpdateNewsAsync(id,newsModel));

        }
    }
    }
