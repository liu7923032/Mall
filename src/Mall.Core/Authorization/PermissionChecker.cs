using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Runtime.Session;
using Castle.Core.Logging;

namespace Mall.Authorization
{
    /// <summary>
    /// 自定义权限检查
    /// </summary>
    public class PermissionChecker : IPermissionChecker, ITransientDependency
    {

        public ILogger Logger { get; set; }

        public IAbpSession AbpSession { get; set; }

        public PermissionChecker()
        {
            AbpSession = NullAbpSession.Instance;
            Logger = NullLogger.Instance;
        }


        public Task<bool> IsGrantedAsync(string permissionName)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            throw new NotImplementedException();
        }
    }
}
