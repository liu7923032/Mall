using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Mall.Authorization;
using Mall.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Mall.LoginApp
{
    public interface ILoginManager
    {
        //Task<>
        Task<Mall_Account> GetUserByAccountAsync(string account);
        Task<Mall_Account> SignAsync(LoginModel login);
        Task<ClaimsPrincipal> GetPrincipalAsync(Mall_Account user, string authenticationType);
    }


    public class LoginManager : ILoginManager, ITransientDependency
    {
        private IRepository<Mall_Account> _accountRepository;


        public LoginManager(IRepository<Mall_Account> repository)
        {
            _accountRepository = repository;
        }

        public async Task<Mall_Account> GetUserByAccountAsync(string account)
        {
            return await _accountRepository.FirstOrDefaultAsync(u => u.Account.Equals(account));
        }

        public async Task<Mall_Account> SignAsync(LoginModel login)
        {
            //1:检查账号是否存在
            var user = await GetUserByAccountAsync(login.Account);
            if (user == null)
            {
                throw new AbpException("账号不存在");
            }
            //2:检查密码是否匹配
            if (user.Password != login.Password.Trim())
            {
                throw new AbpException("密码错误");
            }
            if (!user.IsActive)
            {
                throw new AbpException("账号未激活");
            }
            if (user.IsLock)
            {
                throw new AbpException("账号被锁住");
            }
            //2:创建身份认证
            //ClaimsIdentity identity = new ClaimsIdentity(authenticationType);
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //identity.AddClaim(new Claim(ClaimTypes.Name, user.Account));
            //return await Task.FromResult< new ClaimsPrincipal(identity);
            return await Task.FromResult(user);
        }

        public async Task<ClaimsPrincipal> GetPrincipalAsync(Mall_Account user,string authenticationType)
        {
            ClaimsIdentity identity = new ClaimsIdentity(authenticationType);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Account));
            return await Task.FromResult(new ClaimsPrincipal(identity));
        }

       
    }
}
