using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MVCBlogApp.Persistence.Contexts;

namespace MVCBlogApp.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MVCBlogDbContext>
    {
        public MVCBlogDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MVCBlogDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConfigurationString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
