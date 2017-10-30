using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Mall.Category;
using Mall.Product;
using Mall.Web.Models.Home;
using Mall.Web.Startup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
    public class HomeController : MallControllerBase
    {
        private ICategoryAppService _categoryService;

        private IProductAppService _productService;

        public HomeController(ICategoryAppService categoryService, IProductAppService productAppService)
        {
            _categoryService = categoryService;
            _productService = productAppService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = (await _categoryService.GetAll(new GetAllCategoryInput()
            {
                MaxResultCount=10,
                SkipCount=0,
                Sorting= "CategoryNo"
            })).Items;

            var model = new CategoryListViewModel
            {
                Categories = categories
            };
            return View(model);
        }

        public async Task<ActionResult> Details(string id)
        {
            return await Task.FromResult(View());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}