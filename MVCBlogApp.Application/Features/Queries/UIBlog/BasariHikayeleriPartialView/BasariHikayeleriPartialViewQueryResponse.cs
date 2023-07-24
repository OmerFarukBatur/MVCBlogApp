using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.BasariHikayeleriPartialView
{
    public class BasariHikayeleriPartialViewQueryResponse
    {
        public PagedResult<VM_Blog> Result { get; set; }
    }
}