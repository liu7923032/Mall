using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Mall.Cache;
using Mall.Domain.Entities;

namespace Mall.LoginApp
{
    public interface IUserCache : IEntityCache<AccountDto>
    {
        //Task<List<AccountDto>> GetAllUsers();
    }

    public class UserCache : EntityCache<Mall_Account, AccountDto>, IUserCache, ISingletonDependency
    {
        private IRepository<Mall_Account> _accountRepository;
        private ICacheManager _cacheManager;
        public UserCache(ICacheManager cacheManager, IRepository<Mall_Account> repository, string cacheName = CacheNames.Users) : base(cacheManager, repository)
        {
            _accountRepository = repository;
            _cacheManager = cacheManager;
        }

        //public async Task<List<AccountDto>> GetAllUsers()
        //{

        //    _cacheManager.get
        //    throw new NotImplementedException();
        //}
    }
}
