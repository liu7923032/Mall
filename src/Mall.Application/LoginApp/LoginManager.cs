﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Mall.Authorization;
using Mall.Cache;
using Mall.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Mall.LoginApp
{
    public interface IUserManager : IApplicationService
    {
        //通过账号来获取登陆对象
        Task<Mall_Account> GetUserByAccountAsync(string account);
        //登陆系统
        Task<Mall_Account> SignAsync(LoginModel login);
        //创建证件当事人
        Task<ClaimsPrincipal> GetPrincipalAsync(Mall_Account user, string authenticationType);
        //通过用户来获取账号人员信息
        Task<AccountDto> GetUserById(int id);

        Task InsertUser(CreateAccountInput input);
    }


    public class UserManager : MallAppServiceBase, IUserManager
    {
        private IRepository<Mall_Account> _accountRepository;
        private IUserCache _userCache;

        public UserManager(IRepository<Mall_Account> repository, IUserCache userCache)
        {
            _accountRepository = repository;
            _userCache = userCache;
        }

        public async Task<AccountDto> GetUserById(int id)
        {
            return await _userCache.GetAsync(id);
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
            //if (user.Password != login.Password.Trim())
            //{
            //    throw new AbpException("密码错误");
            //}
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

        public async Task<ClaimsPrincipal> GetPrincipalAsync(Mall_Account user, string authenticationType)
        {

            ClaimsIdentity identity = new ClaimsIdentity(authenticationType);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Account));
            return await Task.FromResult(new ClaimsPrincipal(identity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task InsertUser(CreateAccountInput input)
        {
            var user = input.MapTo<Mall_Account>();
            await _accountRepository.InsertAsync(user);
        }
    }
}
