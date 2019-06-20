using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UltimateInvocing.Configuration;
using UltimateInvocing.Web;

namespace UltimateInvocing.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class UltimateInvocingDbContextFactory : IDesignTimeDbContextFactory<UltimateInvocingDbContext>
    {
        public UltimateInvocingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UltimateInvocingDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            UltimateInvocingDbContextConfigurer.Configure(builder, configuration.GetConnectionString(UltimateInvocingConsts.ConnectionStringName));

            return new UltimateInvocingDbContext(builder.Options);
        }
    }
}
