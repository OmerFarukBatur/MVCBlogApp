using Microsoft.Extensions.DependencyInjection;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Infrastructure.Services;

namespace MVCBlogApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection collection)
        {
            collection.AddScoped<IOperationService, OperationService>();
        }
    }
}
