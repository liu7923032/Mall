using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Mall.Authorization;

namespace Mall
{
    [DependsOn(
        typeof(MallCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MallApplicationModule : AbpModule
    {

        public override void PreInitialize()
        {
            //base.PreInitialize();
            Configuration.Authorization.Providers.Add<MallAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MallApplicationModule).GetAssembly());
        }
    }
}