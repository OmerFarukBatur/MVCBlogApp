using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Admin.Event.GetEventCreateItems
{
    public class GetEventCreateItemsQueryResponse
    {
        public List<AllStatus> Statuses { get; set; }
        public List<VM_EventCategory> EventCategories { get; set; }
    }
}