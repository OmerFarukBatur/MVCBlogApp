using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetAllWorkshopCategory
{
    public class GetAllWorkshopCategoryQueryResponse
    {
        public List<VM_WorkshopCategory> WorkshopCategories { get; set; }
    }
}