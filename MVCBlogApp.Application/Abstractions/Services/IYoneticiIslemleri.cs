using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyCreate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetAllTKBiography;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetTKBiographyCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IYoneticiIslemleri
    {
        #region Admin

        Task<AdminCreateCommandResponse> CreateAdminAsync(AdminCreateCommandRequest request);
        Task<AdminRoleListQueryResponse> AdminListRoleAsync();
        Task<AllAdminQueryResponse> AllAdminAsync();
        Task<AdminUpdateCommandResponse> UpdateAdminAsync(AdminUpdateCommandRequest request);
        Task<GetByIdAdminQueryResponse> GetByIdAdminAsync(int id);
        Task<AdminByIdRemoveCommandResponse> AdminDeleteAsync(AdminByIdRemoveCommandRequest request);

        #endregion

        #region TK

        Task<GetTKBiographyCreateItemsQueryResponse> GetTKBiographyCreateItemsAsync();
        Task<GetAllTKBiographyQueryResponse> GetAllTKBiographyAsync();
        Task<TKBiographyCreateCommandResponse> TKBiographyCreateAsync(TKBiographyCreateCommandRequest request);

        #endregion
    }
}
