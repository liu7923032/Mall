using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Mall
{
    [DependsOn(
        typeof(MallCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MallApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MallApplicationModule).GetAssembly());
        }
    }
}