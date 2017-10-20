using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Mall.Domain.Entities;

namespace Mall.LoginApp
{
    public interface ILoginManager
    {
        //Task<>
        Task<Mall_Account> GetAccount(string account);
        //验证账号是否有错误
        Task<string> ValidateError(Mall_Account mall, string pwd);

    }


    public class LoginManager : ILoginManager, ITransientDependency
    {
        private IRepository<Mall_Account> _accountRepository;
        public LoginManager(IRepository<Mall_Account> repository)
        {
            _accountRepository = repository;
        }

        public async Task<Mall_Account> GetAccount(string account)
        {
            return await _accountRepository.FirstOrDefaultAsync(u => u.Account.Equals(account));
        }

        public Task<string> ValidateError(Mall_Account mall, string pwd)
        {
            //1:检查密码
            //2:检查是否激活
            //3:检查是否授权
            return Task.FromResult("");
        }
    }
}
