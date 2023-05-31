using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Admin.Calendar.GetAllCalendarEvent
{
    public class GetAllCalendarEventQueryResponse
    {
        public List<VM_CalenderData> AllEvents { get; set; }
    }
}