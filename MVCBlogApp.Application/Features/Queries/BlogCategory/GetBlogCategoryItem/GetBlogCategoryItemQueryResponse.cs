using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BlogCategory.GetBlogCategoryItem
{
    public class GetBlogCategoryItemQueryResponse
    {
        public List<VM_Language> Languages { get; set; }
        public List<AllStatus> Status { get; set; }
    }
}