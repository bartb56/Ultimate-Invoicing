using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace UltimateInvocing.EntityFrameworkCore
{
    public static class UltimateInvocingDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<UltimateInvocingDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<UltimateInvocingDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
