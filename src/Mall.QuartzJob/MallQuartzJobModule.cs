using System;
using Abp.Modules;
using Abp.Quartz;
using Mall.QuartzJob.Jobs;
using Quartz;

namespace Mall.QuartzJob
{
    [DependsOn(typeof(AbpQuartzModule), typeof(MallCoreModule))]
    public class MallQuartzJobModule : AbpModule
    {



        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MallQuartzJobModule).Assembly);
        }

        public override void PostInitialize()
        {
            var jobManager = IocManager.Resolve<IQuartzScheduleJobManager>();
            //执行调度系统
            jobManager.ScheduleAsync<SyncPriceJob>(
                job =>
                {
                    job.WithIdentity(nameof(SyncPriceJob), "Group")
                        .WithDescription("A job to sync price from internet.");
                },
                trigger =>
                {
                    trigger.StartNow()
                        .WithCronSchedule("0 0 1 * * ?");
                });
        }
    }
}
