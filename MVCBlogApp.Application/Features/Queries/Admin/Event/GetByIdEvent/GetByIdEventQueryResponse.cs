using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Admin.Event.GetByIdEvent
{
    public class GetByIdEventQueryResponse
    {
        public List<AllStatus>? Statuses { get; set; }
        public List<VM_EventCategory>? EventCategories { get; set; }
        public VM_Event? Event { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}