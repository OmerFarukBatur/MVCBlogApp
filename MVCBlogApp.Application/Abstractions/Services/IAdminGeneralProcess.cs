using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IAdminGeneralProcess
    {
        #region AdminCalendar

        #region Event



        #endregion

        #region EventCategory

        Task<GetAllEventCategoryQueryResponse> GetAllEventCategoryAsync();
        Task<EventCategoryCreateCommandResponse> EventCategoryCreateAsync(EventCategoryCreateCommandRequest request); 
        Task<GetByIdEventCategoryQueryResponse> GetByIdEventCategoryAsync(int id);
        Task<EventCategoryUpdateCommandResponse> EventCategoryUpdateAsync(EventCategoryUpdateCommandRequest request);
        Task<EventCategoryDeleteCommandResponse> EventCategoryDeleteAsync(int id);

        #endregion

        #endregion
    }
}
