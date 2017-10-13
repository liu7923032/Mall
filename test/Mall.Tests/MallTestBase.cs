using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Mall.EntityFrameworkCore;
using Mall.Tests.TestDatas;

namespace Mall.Tests
{
    public class MallTestBase : AbpIntegratedTestBase<MallTestModule>
    {
        public MallTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<MallDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<MallDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<MallDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MallDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<MallDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<MallDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<MallDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MallDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
