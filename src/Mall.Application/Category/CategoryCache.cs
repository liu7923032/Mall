using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Runtime.Caching;
using Mall.Cache;
using Mall.Domain.Entities;

namespace Mall.Category
{
    public interface ICategoryCache : IEntityCache<CategoryDto>
    {
        Task<List<CategoryDto>> GetCategories();
    }

    public class CategoryCache : EntityCache<Mall_Category, CategoryDto>, ICategoryCache, ISingletonDependency
    {
        private ICacheManager _cacheManager;
        public CategoryCache(ICacheManager cacheManager, IRepository<Mall_Category> categoryRepository) : base(cacheManager, categoryRepository)
        {
            _cacheManager = cacheManager;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _cacheManager.GetCache(nameof(CacheNames)).GetAsync(CacheNames.Category, async () => await Task.FromResult(base.Repository.GetAllList().MapTo<List<CategoryDto>>()));

        }

        /// <summary>
        /// 数据变更的时候,给对应的缓存也更新掉
        /// </summary>
        /// <param name="eventData"></param>
        public override void HandleEvent(EntityChangedEventData<Mall_Category> eventData)
        {
            _cacheManager.GetCache(nameof(CacheNames)).Remove(CacheNames.Category);
            base.HandleEvent(eventData);
        }
    }
}
