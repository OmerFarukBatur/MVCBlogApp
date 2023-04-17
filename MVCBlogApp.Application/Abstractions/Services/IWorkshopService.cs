using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeDelete;
using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetByIdWorkshopType;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetWorkshopTypeCreateItems;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IWorkshopService
    {
        #region Workshop



        #endregion

        #region WorkShopApplicationForms



        #endregion

        #region WorkshopCategory



        #endregion

        #region WorkshopEducation



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
