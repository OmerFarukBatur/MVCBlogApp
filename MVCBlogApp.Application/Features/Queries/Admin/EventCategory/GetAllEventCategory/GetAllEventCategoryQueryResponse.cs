using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Admin.EventCategory.GetAllEventCategory
{
    public class GetAllEventCategoryQueryResponse
    {
        public List<VM_EventCategory> EventCategories { get; set; }
    }
}