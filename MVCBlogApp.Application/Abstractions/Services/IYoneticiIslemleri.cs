using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IYoneticiIslemleri
    {
        Task<AdminCreateCommandResponse> CreateAdmin(AdminCreateCommandRequest request);
        Task<AdminRoleListQueryResponse> AdminListRole();
    }
}
