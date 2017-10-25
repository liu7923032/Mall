using Abp.Application.Services;
using Abp.Authorization;

namespace Mall
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    [AbpAuthorize]
    public abstract class MallAppServiceBase : ApplicationService
    {
        protected MallAppServiceBase()
        {
            LocalizationSourceName = MallConsts.LocalizationSourceName;
        }
    }
}