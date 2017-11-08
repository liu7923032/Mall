using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Mall.Cache;
using Mall.Domain.Entities;
using Mall.LoginApp;
using Mall.Runtime;
using Mall.Web.Startup;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Views.Shared.Components.User
{
    public class UserViewComponent : MallViewComponent
    {
        private ILoginManager _loginManager;

        public UserViewComponent(ILoginManager loginManager, ICacheManager cacheManager)
        {
            _loginManager = loginManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserViewModel model = new UserViewModel();
            if (AbpSession.UserId.HasValue)
            {
                //此处使用缓存,将users对象都放到缓存中
                var user = await _loginManager.GetUserById(AbpSession.GetUserId());
                model.Account = user.Account;
                model.UserName = user.Account;
            }
            return View(model);
        }
    }
}
