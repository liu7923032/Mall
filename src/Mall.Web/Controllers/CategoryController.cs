using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Caching;
using Abp.Web.Models;
using Mall.Category;
using Mall.Web.Models.Home;
using Mall.Web.Startup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
    public class CategoryController : MallControllerBase
    {
        private ICategoryAppService _categoryService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }

        public async Task<ActionResult> Product()
        {
            var categories = await _categoryService.GetAllListAsync();
            var model = new CategoryListViewModel
            {
                Categories = categories
            };

            return await Task.FromResult(View(model));
        }


        public async Task<AjaxResponse> Upload(IFormFile file)
        {
            
            return await Task.FromResult(new AjaxResponse());
        }
    }
}