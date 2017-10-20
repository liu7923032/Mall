using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;

namespace Mall.Web.Controllers
{
    [AbpMvcAuthorize]
    public abstract class MallControllerBase: AbpController
    {
        protected MallControllerBase()
        {
            LocalizationSourceName = MallConsts.LocalizationSourceName;
        }
    }
}