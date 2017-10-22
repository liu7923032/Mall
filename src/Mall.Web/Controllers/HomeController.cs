using Abp.AspNetCore.Mvc.Authorization;
using Mall.Web.Startup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
    [AbpMvcAuthorize(PageNames.Mall)]
    public class HomeController : MallControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}