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
using Mall.Domain.Entities;
using Abp;

namespace Mall.Web.Controllers
{
    public class AccountController : MallControllerBase
    {
        private ILoginManager _loginManager;

        private static readonly string CookieScheme = "AppAuthenticationScheme";

        public AccountController(ILoginManager loginManager)
        {
            _loginManager = loginManager;

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromBody]LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                throw new AbpException("");
            }
            //身份认证
            var user = await _loginManager.SignAsync(login);
            //证件当事人
            var claimPrincipal = await _loginManager.GetPrincipalAsync(user, CookieScheme);
            //系统登陆
            await HttpContext.SignInAsync(CookieScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = login.IsRemember });
            //跳转地址
            return Redirect("/Home/Index");
        }

        /// <summary>
        /// 通过其他方式登陆
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLogin()
        {
            string account = Request.Query["gongHao"];
            //如果账号不存在,那么直接跳转到登陆页面
            if (string.IsNullOrEmpty(account))
            {
                return Redirect("/Account/Login");
            }
            //var loginUser = Request.Cookies["MDSD.LoginUser"];
            //获取当前信息
            var user = await _loginManager.GetUserByAccountAsync(account);
            //获取证件当事人
            var claimPrincipal = await _loginManager.GetPrincipalAsync(user, CookieScheme);
            //登陆系统
            await HttpContext.SignInAsync(CookieScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = false });
            //跳转地址
            return Redirect("/Home/Index");
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

       
    }
}