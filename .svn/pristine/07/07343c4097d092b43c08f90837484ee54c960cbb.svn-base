using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Caching;
using Mall.Cache;
using Mall.UserApp;
using Mall.Runtime;
using Microsoft.AspNetCore.Mvc;
using Mall.Cart;
using Dark.Common.Utils;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Abp.Timing;

namespace Mall.Web.Controllers
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class CartController : MallControllerBase
    {
        private IUserAppService _loginManager;
        private ICartAppService _cartAppService;
        private IHostingEnvironment _env;
        public CartController(IUserAppService loginManager, ICartAppService cartAppService, IHostingEnvironment env)
        {
            _loginManager = loginManager;
            _cartAppService = cartAppService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            //获取当前人员的积分信息
            var user = await _loginManager.GetUserById(AbpSession.GetUserId());
            ViewBag.Integral = user.Integral;

            return View();
        }

        /// <summary>
        /// 下载Excel
        /// </summary>
        /// <returns></returns>
        public async Task<FileResult> DownExcel(GetItemsInput input)
        {
            MemoryStream msData = new MemoryStream(10);

            var result = await _cartAppService.GetCartByIds(input);
            //创建一个临时文件
            string filePath = $"{_env.WebRootPath }\\TempFile\\";
            Stream stream = new ExcelTool<CartItemDto>().GetExcelByList(filePath, result.Items);
            return ToExcel(stream);

        }
    }
}