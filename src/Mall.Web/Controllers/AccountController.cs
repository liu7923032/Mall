using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mall.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Abp.Runtime.Session;
using Abp.Web.Models;
using Abp.Auditing;

namespace Mall.Web.Controllers
{
    public class AccountController : MallControllerBase
    {
        private IAuthenticationService _authenticationService;

        private IAbpSession _abpSession;

        public AccountController(IAuthenticationService authenticationService,IAbpSession abpSession)
        {
            _authenticationService = authenticationService;
            _abpSession = abpSession;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public async Task<JsonResult> LoginAsync(LoginModel login)
        {
            //创建身份证
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim("UserId", "000"));
            //创建证件管理者
            var claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.AddIdentity(new ClaimsIdentity());
            //系统登陆
            await _authenticationService.SignInAsync(HttpContext, "", new ClaimsPrincipal(), new AuthenticationProperties() { IsPersistent = true });

            return Json(new AjaxResponse { TargetUrl = "/Home/Index" });
            //await HttpContext.Authentication.SignInAsync("MyCookieAuthenticationScheme", principal);
            //return null;
        }

        [HttpPost]
        [DisableAuditing]
        public async Task<JsonResult> Test()
        {
            return Json(new AjaxResponse());
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}