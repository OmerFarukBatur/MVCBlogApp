using MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate;
using MVCBlogApp.Application.Features.Queries.Workshop.WorkshopType.GetAllWorkshopType;
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

        #endregion
    }
}
