using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mall.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Mall.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task LoginAysnc(LoginModel login)
        {
            //创建身份证
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim("UserId", "000"));
            //创建证件管理者
            var claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.AddIdentity(new ClaimsIdentity());
            //系统登陆
            await _authenticationService.SignInAsync(HttpContext, "", new ClaimsPrincipal(), new AuthenticationProperties() { IsPersistent = true });
            //await HttpContext.Authentication.SignInAsync("MyCookieAuthenticationScheme", principal);
            //return null;
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}