using Abp.Modules;
using Abp.Reflection.Extensions;
using Mall.Localization;

namespace Mall
{
    public class MallCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;



            MallLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MallCoreModule).GetAssembly());
        }
    }
}