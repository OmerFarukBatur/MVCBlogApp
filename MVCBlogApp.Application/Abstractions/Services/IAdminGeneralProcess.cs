using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;

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

        #endregion

        #endregion
    }
}
