using System;
using System.Collections.Generic;
using System.Text;
using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Mall.Domain.Entities;

namespace Mall.Product
{

    public interface IProductCache : IEntityCache<ProductDto>
    {

    }

    /// <summary>
    /// 缓存类  
    /// http://www.jianshu.com/p/241793caa328 示例 还包含相关demo
    /// </summary>
    public class ProductCache : EntityCache<Mall_Product, ProductDto>, IProductCache, ISingletonDependency
    {
        public ProductCache(ICacheManager cacheManager, IRepository<Mall_Product> repository, string cacheName = "Application.ProductCache")
            : base(cacheManager, repository, cacheName)
        {

        }
    }
}
