using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }


        public async Task<ActionResult> Product()
        {
            return await Task.FromResult(View());
        }
    }
}