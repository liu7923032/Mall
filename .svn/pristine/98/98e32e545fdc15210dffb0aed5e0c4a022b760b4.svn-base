using Mall.Configuration;
using Mall.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Mall.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class MallDbContextFactory : IDesignTimeDbContextFactory<MallDbContext>
    {
        public MallDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MallDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(MallConsts.ConnectionStringName)
            );

            return new MallDbContext(builder.Options);
        }
    }
}