using System;
using System.Collections.Generic;
using System.Text;
using Abp.Dependency;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Mall.LoginApp;

namespace Mall.BackgroundJobs
{
    public class SyncUserWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private IUserManager _loginManager;
        public SyncUserWorker(AbpTimer timer, IUserManager loginManager) : base(timer)
        {
            _loginManager = loginManager;
            //
            timer.Period = 1000 * 60;
        }

        //同步人员信息
        protected override void DoWork()
        {

            //
        }
    }
}
