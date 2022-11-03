using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AngularTest.EntityFrameworkCore
{
    public static class AngularTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AngularTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AngularTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
