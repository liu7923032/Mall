using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
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