using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IYoneticiIslemleri
    {
        Task<AdminCreateCommandResponse> CreateAdminAsync(AdminCreateCommandRequest request);
        Task<AdminRoleListQueryResponse> AdminListRoleAsync();
        Task<AllAdminQueryResponse> AllAdminAsync();
    }
}
