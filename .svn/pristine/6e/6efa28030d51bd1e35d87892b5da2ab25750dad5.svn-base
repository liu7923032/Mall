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
        public UserCache(ICacheManager cacheManager, IRepository<Mall_Account> repository) : base(cacheManager, repository)
        {
           
        }

        //public async Task<List<AccountDto>> GetAllUsers()
        //{

        //    _cacheManager.get
        //    throw new NotImplementedException();
        //}
    }
}
