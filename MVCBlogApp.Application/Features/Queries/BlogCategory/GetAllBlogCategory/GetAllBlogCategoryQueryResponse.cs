using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.BlogCategory.GetAllBlogCategory
{
    public class GetAllBlogCategoryQueryResponse
    {
        public List<VM_AllBlogCategory> AllCategory { get; set; }
    }
}