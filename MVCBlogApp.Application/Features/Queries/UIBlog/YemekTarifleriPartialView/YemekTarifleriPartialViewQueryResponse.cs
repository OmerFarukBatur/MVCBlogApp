using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Queries.UIBlog.YemekTarifleriPartialView
{
    public class YemekTarifleriPartialViewQueryResponse
    {
        public PagedResult<VM_Blog> Result { get; set; }
    }
}