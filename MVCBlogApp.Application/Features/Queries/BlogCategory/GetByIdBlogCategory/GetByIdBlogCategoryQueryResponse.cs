using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BlogCategory.GetByIdBlogCategory
{
    public class GetByIdBlogCategoryQueryResponse
    {
        public VM_BlogCategory? BlogCategory { get; set; }
        public List<AllStatus>? AllStatuses { get; set; }
        public List<VM_Language>? AllLanguages { get; set; }
        public bool State { get; set; }
    }
}