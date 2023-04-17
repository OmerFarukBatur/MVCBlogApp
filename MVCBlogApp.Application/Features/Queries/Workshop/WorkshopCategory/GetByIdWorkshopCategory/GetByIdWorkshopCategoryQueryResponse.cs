using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Workshop.WorkshopCategory.GetByIdWorkshopCategory
{
    public class GetByIdWorkshopCategoryQueryResponse
    {
        public List<VM_Language>? Languages { get; set; }
        public VM_WorkshopCategory? WorkshopCategory { get; set; }
        public string? Message { get; set; }
        public bool State { get; set; }
    }
}