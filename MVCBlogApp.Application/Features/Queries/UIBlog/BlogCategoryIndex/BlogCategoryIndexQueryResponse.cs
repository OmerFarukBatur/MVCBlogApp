using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.BlogCategoryIndex
{
    public class BlogCategoryIndexQueryResponse
    {
        public List<VM_Blog> Blogs { get; set; }
    }
}