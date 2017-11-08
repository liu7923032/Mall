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

namespace Mall.Product
{

    public interface IProductCache : IEntityCache<ProductDto>
    {
        Task<List<ProductDto>> GetProudcts();
    }

    /// <summary>
    /// 缓存类  
    /// http://www.jianshu.com/p/241793caa328 示例 还包含相关demo
    /// </summary>
    public class ProductCache : EntityCache<Mall_Product, ProductDto>, IProductCache, ISingletonDependency
    {

        private ICacheManager _cacheManager;

        public ProductCache(ICacheManager cacheManager, IRepository<Mall_Product> productRepository)
            : base(cacheManager, productRepository)
        {
            _cacheManager = cacheManager;
        }

        public async Task<List<ProductDto>> GetProudcts()
        {


            return await _cacheManager.GetCache(nameof(CacheNames)).GetAsync(CacheNames.Product, async () => await Task.FromResult(base.Repository.GetAllIncluding(u => u.Category).MapTo<List<ProductDto>>()));
        }

        public override void HandleEvent(EntityChangedEventData<Mall_Product> eventData)
        {
            _cacheManager.GetCache(nameof(CacheNames)).Remove(CacheNames.Product);
            base.HandleEvent(eventData);
        }
    }
}
