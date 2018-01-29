using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Quartz;
using Castle.Core.Logging;
using Dark.Common.Crawler;
using Dark.Common.Serializer;
using Dark.Common.Utils;
using Mall.Domain.Entities;
using Mall.Product;
using Quartz;

namespace Mall.QuartzJob.Jobs
{
    public class SyncPriceJob : JobBase, ITransientDependency
    {
        private IRepository<Mall_Product> _productRepository;
        public SyncPriceJob(IRepository<Mall_Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            //获取所有的商品价格
            var pList = await _productRepository.GetAllListAsync(u => !string.IsNullOrEmpty(u.LinkAddr));

            //通过爬虫来获取所有的数据
            pList.ForEach(async u =>
            {
                //如果商品编号为空,通过地址来获取商品的对应的编号
                if (string.IsNullOrEmpty(u.Skuid))
                {
                    CrawlerOptions crawlerOptions = new CrawlerOptions()
                    {
                        Url = u.LinkAddr,
                        CssSelectors = new List<SelectorOptions>()
                        {
                            new SelectorOptions("skuid","#detail > div.tab-con > div:nth-child(1) > div.p-parameter > ul.parameter2.p-parameter-list > li:nth-child(2)")
                        }
                    };

                    var crawler = await CrawlerTool.GetResultAsync(crawlerOptions);
                    string skuid = crawler["skuid"].FirstOrDefault()?.Attributes["title"];
                    if (!string.IsNullOrEmpty(skuid))
                    {
                        u.Skuid = skuid;
                        await GetAndSetPrice(skuid, u);
                    }
                }
                else
                {
                    await GetAndSetPrice(u.Skuid, u);
                }
            });
        }

        /// <summary>
        /// 通过skuids来获取商品的价格
        /// </summary>
        /// <param name="skuid"></param>
        /// <param name="product">商品实体</param>
        /// <returns></returns>
        private async Task GetAndSetPrice(string skuid, Mall_Product product)
        {
            string strPrice = await HttpTools.GetStringAsync($"http://p.3.cn/prices/mgets?skuIds={skuid}");
            List<ProductPrice> pList = JsonTools.ToList<ProductPrice>(strPrice);

            decimal nowPrice = Math.Ceiling(pList[0].p);
            if (nowPrice != 0 && nowPrice != product.Price)
            {
                Logger.Info($"商品:{product.Name},原价格:{product.Price},新价格:{nowPrice}");
                product.Price = nowPrice;
            }
            await _productRepository.UpdateAsync(product);
        }
    }

    public class ProductPrice
    {
        public decimal p { get; set; }
    }
}
