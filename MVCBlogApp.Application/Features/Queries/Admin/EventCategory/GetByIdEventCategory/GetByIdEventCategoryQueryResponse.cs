using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetByIdEventCategory
{
    public class GetByIdEventCategoryQueryResponse
    {
        public string? Message { get; set; }
        public bool State { get; set; }
        public VM_EventCategory? EventCategory { get; set; }
    }
}