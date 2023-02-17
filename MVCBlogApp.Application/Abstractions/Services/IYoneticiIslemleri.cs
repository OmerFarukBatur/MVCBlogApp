using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IYoneticiIslemleri
    {
        Task<AdminCreateCommandResponse> CreateAdminAsync(AdminCreateCommandRequest request);
        Task<AdminRoleListQueryResponse> AdminListRoleAsync();
        Task<AllAdminQueryResponse> AllAdminAsync();
        Task<AdminUpdateCommandResponse> UpdateAdminAsync(int id);
        Task<GetByIdAdminQueryResponse> GetByIdAdminAsync(int id);
    }
}
