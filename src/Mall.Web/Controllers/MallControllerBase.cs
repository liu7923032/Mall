using System.IO;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Timing;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
    [AbpMvcAuthorize]
    public abstract class MallControllerBase : AbpController
    {
        protected MallControllerBase()
        {
            LocalizationSourceName = MallConsts.LocalizationSourceName;
        }


        protected string GetExcelDir()
        {
            return string.Empty;
        }

        protected FileResult ToExcel(Stream fs, string fileName = "")
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = $"{Clock.Now.ToString("yyyy-MM-dd")}.xlsx";

            }
            return File(fs, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}