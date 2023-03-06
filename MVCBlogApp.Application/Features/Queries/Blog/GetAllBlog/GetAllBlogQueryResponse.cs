using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.Blog.GetAllBlog
{
    public class GetAllBlogQueryResponse
    {
        public List<VM_Blog> Blogs { get; set; }
    }
}