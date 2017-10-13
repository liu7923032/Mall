using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
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
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MallConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MallNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MallApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MallWebModule).GetAssembly());
        }
    }
}