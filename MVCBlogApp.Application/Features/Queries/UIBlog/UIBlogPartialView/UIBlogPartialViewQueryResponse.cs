using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.UIBlogPartialView
{
    public class UIBlogPartialViewQueryResponse
    {
        public PagedResult<VM_Blog> Result { get; set; }
    }
}