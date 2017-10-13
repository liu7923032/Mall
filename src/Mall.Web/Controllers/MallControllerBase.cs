using Abp.AspNetCore.Mvc.Controllers;

namespace Mall.Web.Controllers
{
    public abstract class MallControllerBase: AbpController
    {
        protected MallControllerBase()
        {
            LocalizationSourceName = MallConsts.LocalizationSourceName;
        }
    }
}