using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Mall.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Views.Shared.Components.User
{
    public class UserViewComponent : MallViewComponent
    {
        private IRepository<Mall_Account> _accountRepository;
        public UserViewComponent(IRepository<Mall_Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserViewModel model = new UserViewModel();
            if (AbpSession.UserId.HasValue)
            {
                int userID = Convert.ToInt32(AbpSession.UserId.Value);
                var user = await _accountRepository.FirstOrDefaultAsync(u => u.Id.Equals(userID));
                model.Account = user.Account;
                model.UserName = user.Account;
            }
            return View(model);
        }
    }
}
