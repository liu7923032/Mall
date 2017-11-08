using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Caching;
using Mall.Cache;
using Mall.LoginApp;
using Mall.Runtime;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class CartController : MallControllerBase
    {
        private ILoginManager _loginManager;
        public CartController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }
        public async Task<IActionResult> Index()
        {
            //获取当前人员的积分信息
            var user = await _loginManager.GetUserById(AbpSession.GetUserId());
            ViewBag.Integral = user.Integral;

            return View();
        }
    }
}