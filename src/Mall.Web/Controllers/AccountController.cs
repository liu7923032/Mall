using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mall.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Abp.Web.Models;
using Mall.LoginApp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Abp.Runtime.Session;
using System.Threading;

namespace Mall.Web.Controllers
{
    public class AccountController : MallControllerBase
    {
        private ILoginManager _loginManager;

        private IAbpSession _abpSession;

        

        public AccountController(ILoginManager loginManager
            , IAbpSession abpSession)
        {
            _loginManager = loginManager;
            _abpSession = abpSession;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> LoginAsync([FromBody]LoginModel login)
        {
            if (!ModelState.IsValid)
            {

            }

            var user = await _loginManager.GetAccount(login.Account);

            string result = await _loginManager.ValidateError(user, login.Password);

            if (!string.IsNullOrEmpty(result))
            {

            }


            //创建身份证
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Account));
            //创建证件管理者

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            //Thread.CurrentPrincipal = claimsPrincipal;

            //系统登陆
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties() { IsPersistent = login.IsRemember });

            
            
            return Json(new AjaxResponse { TargetUrl = "/Home/Index" });
            //await HttpContext.Authentication.SignInAsync("MyCookieAuthenticationScheme", principal);
            //return null;
        }

        /// <summary>
        /// 登陆页面
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Test(string id)
        {
            return Json(new AjaxResponse() { TargetUrl = "/Home/Index" });
        }
    }
}