using MVCBlogApp.Application.Features.Commands.Admin.Calendar.EventDateTimeUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventCreate;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventDelete;
using MVCBlogApp.Application.Features.Commands.Admin.Event.EventUpdate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryCreate;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryDelete;
using MVCBlogApp.Application.Features.Commands.Admin.EventCategory.EventCategoryUpdate;
using MVCBlogApp.Application.Features.Queries.Admin.Calendar.GetAllCalendarEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetAllEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetByIdEvent;
using MVCBlogApp.Application.Features.Queries.Admin.Event.GetEventCreateItems;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory;
using MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory;

namespace MVCBlogApp.Application.Abstractions.Services
{
    public interface IAdminGeneralProcess
    {
        #region AdminCalendar

        #region Event

        Task<GetEventCreateItemsQueryResponse> GetEventCreateItemsAsync();
        Task<GetAllEventQueryResponse> GetAllEventAsync();
        Task<EventCreateCommandResponse> EventCreateAsync(EventCreateCommandRequest request);
        Task<GetByIdEventQueryResponse> GetByIdEventAsync(int id);
        Task<EventUpdateCommandResponse> EventUpdateAsync(EventUpdateCommandRequest request);
        Task<EventDeleteCommandResponse> EventDeleteAsync(int id);

        #endregion

        #region EventCategory

        Task<GetAllEventCategoryQueryResponse> GetAllEventCategoryAsync();
        Task<EventCategoryCreateCommandResponse> EventCategoryCreateAsync(EventCategoryCreateCommandRequest request); 
        Task<GetByIdEventCategoryQueryResponse> GetByIdEventCategoryAsync(int id);
        Task<EventCategoryUpdateCommandResponse> EventCategoryUpdateAsync(EventCategoryUpdateCommandRequest request);
        Task<EventCategoryDeleteCommandResponse> EventCategoryDeleteAsync(int id);

        #endregion

        #region Calendar

        Task<GetAllCalendarEventQueryResponse> GetAllCalendarEventAsync();
        Task<EventDateTimeUpdateCommandResponse> EventDateTimeAsync(EventDateTimeUpdateCommandRequest request);

        #endregion

        #endregion
    }
}
