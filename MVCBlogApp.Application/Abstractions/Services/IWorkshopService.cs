using MVCBlogApp.Application.Features.Commands.Workshop.Workshop.WorkshopCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopCategory.WorkshopCategoryUpdate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationUpdate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetAllWorkshop;
using MVCBlogApp.Application.Features.Queries.Workshop.Workshop.GetWorkshopCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetAllWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetByIdWorkshopCategory;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetWorkshopCategoryCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetAllWorkshopEducation;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetByIdWorkshopEducation;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopEducation.GetWorkshopEducationCreateItems;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IWorkshopService
    {
        #region Workshop

        Task<GetWorkshopCreateItemsQueryResponse> GetWorkshopCreateItemsAsync();
        Task<GetAllWorkshopQueryResponse> GetAllWorkshopAsync();
        Task<WorkshopCreateCommandResponse> WorkshopCreateAsync(WorkshopCreateCommandRequest request);

        #endregion

        #region WorkShopApplicationForms



        #endregion

        #region WorkshopCategory

        Task<GetWorkshopCategoryCreateItemsQueryResponse> GetWorkshopCategoryCreateItemsAsync();
        Task<GetAllWorkshopCategoryQueryResponse> GetAllWorkshopCategoryAsync();
        Task<WorkshopCategoryCreateCommandResponse> WorkshopCategoryCreateAsync(WorkshopCategoryCreateCommandRequest request);
        Task<GetByIdWorkshopCategoryQueryResponse> GetByIdWorkshopCategoryAsync(int id);
        Task<WorkshopCategoryUpdateCommandResponse> WorkshopCategoryUpdateAsync(WorkshopCategoryUpdateCommandRequest request);
        Task<WorkshopCategoryDeleteCommandResponse> WorkshopCategoryDeleteAsync(int id);

        #endregion

        #region WorkshopEducation

        Task<GetWorkshopEducationCreateItemsQueryResponse> GetWorkshopEducationCreateItemsAsync();
        Task<GetAllWorkshopEducationQueryResponse> GetAllWorkshopEducationAsync();
        Task<WorkshopEducationCreateCommandResponse> WorkshopEducationCreateAsync(WorkshopEducationCreateCommandRequest request);
        Task<GetByIdWorkshopEducationQueryResponse> GetByIdWorkshopEducationAsync(int id);
        Task<WorkshopEducationUpdateCommandResponse> WorkshopEducationUpdateAsync(WorkshopEducationUpdateCommandRequest request);
        Task<WorkshopEducationDeleteCommandResponse> WorkshopEducationDeleteAsync(int id);

        #endregion

        #region WorkshopType

        Task<GetWorkshopTypeCreateItemsQueryResponse> GetWorkshopTypeCreateItemsAsync();
        Task<GetAllWorkshopTypeQueryResponse> GetAllWorkshopTypeAsync();
        Task<WorkshopTypeCreateCommandResponse> WorkshopTypeCreateAsync(WorkshopTypeCreateCommandRequest request);
        Task<GetByIdWorkshopTypeQueryResponse> GetByIdWorkshopTypeAsync(int id);
        Task<WorkshopTypeUpdateCommandResponse> WorkshopTypeUpdateAsync(WorkshopTypeUpdateCommandRequest request);
        Task<WorkshopTypeDeleteCommandResponse> WorkshopTypeDeleteAsync(int id);

        #endregion
    }
}
