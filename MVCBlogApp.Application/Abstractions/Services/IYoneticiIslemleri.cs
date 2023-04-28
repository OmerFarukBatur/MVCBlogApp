using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminByIdRemove;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.AdminUpdate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyCreate;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyDelete;
using MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyUpdate;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AdminRoleList;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.AllAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.GetByIdAdmin;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetAllTKBiography;
using MVCBlogApp.Application.Features.Queries.YoneticiIslemleri.TK.GetByIdTKBiography;
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
        Task<GetByIdTKBiographyQueryResponse>  GetByIdTKBiographyAsync(int id);
        Task<TKBiographyUpdateCommandResponse> TKBiographyUpdateAsync(TKBiographyUpdateCommandRequest request);
        Task<TKBiographyDeleteCommandResponse> TKBiographyDeleteAsync(int id);

        #endregion
    }
}
