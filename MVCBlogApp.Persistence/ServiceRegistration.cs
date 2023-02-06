using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCBlogApp.Persistence.Contexts;

namespace MVCBlogApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            
            services.AddDbContext<MVCBlogDbContext>(options => options.UseSqlServer(Configuration.ConfigurationString));

            // Identity mekanizması için gerekli tablo eklenmesi
            //services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MVCBlogDbContext>();
        }
    }
}
