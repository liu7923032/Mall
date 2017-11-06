using System;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Mall.Configuration;
using Mall.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Mall.Web.Startup
{
    [DependsOn(
        typeof(MallApplicationModule), 
        typeof(MallEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class MallWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MallWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            //1.0 配置连接字符串
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MallConsts.ConnectionStringName);

            //2.0 添加导航菜单
            Configuration.Navigation.Providers.Add<MallNavigationProvider>();


            //3.0 将Application 程序集注册到服务
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MallApplicationModule).GetAssembly()
                );

            //4.0 配置默认的缓存过期时间是10个小时
            Configuration.Caching.ConfigureAll((cache) =>
            {
                cache.DefaultSlidingExpireTime= TimeSpan.FromHours(10);
            });

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MallWebModule).GetAssembly());
        }
    }
}