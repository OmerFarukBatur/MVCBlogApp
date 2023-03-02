using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Abstractions.Storage;
using MVCBlogApp.Infrastructure.Enums;
using MVCBlogApp.Infrastructure.Services;
using MVCBlogApp.Infrastructure.Services.Storage;
using MVCBlogApp.Infrastructure.Services.Storage.Local;

namespace MVCBlogApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection collection)
        {
            collection.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            collection.AddScoped<IOperationService, OperationService>();
            collection.AddScoped<IMailService, MailService>();
            collection.AddScoped<IStorageService, StorageService>();
        }
        public static void AddStorage<T>(this IServiceCollection servicesCollection) where T : Storage, IStorage
        {
            servicesCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection servicesCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    servicesCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                default:
                    servicesCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }

        }
    }
}
