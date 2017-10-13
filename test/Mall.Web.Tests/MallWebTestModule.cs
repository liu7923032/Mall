using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Mall.Web.Startup;

namespace Mall.Web.Tests
{
    [DependsOn(
        typeof(MallWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class MallWebTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MallWebTestModule).GetAssembly());
        }
    }
}